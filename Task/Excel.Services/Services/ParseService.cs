using Excel.Services.Mappers;
using Excel.Services.Settings;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Excel.Services.Services
{
    public class ParseService : IParseService
    {
        private readonly string _protocolPath;
        private readonly DateTime dateOfReference = new DateTime(1900, 1, 1);
        public ParseService(IAppSettings appSettings)
        {
            _protocolPath = appSettings.protocolPath;
        }

        public List<ExcelData> GetDataFromExcel()
        {
            List<ExcelData> excelData;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(_protocolPath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                worksheet.Tables.Add(new ExcelAddressBase(2, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column), "table");
                worksheet.SetValue("X2", "пол");
                excelData = ConvertTableToObjects<ExcelData>(worksheet.Tables.First()).ToList();
            }
            if (!(excelData.First().ToString() != null || excelData.First().ToString() != string.Empty))
            {
                throw new ArgumentException("Source file is invalid");
            }
            return excelData;
        }

        private IEnumerable<T> ConvertTableToObjects<T>(ExcelTable table) where T : new()
        {
            var convertDateTime = new Func<double, DateTime>(excelDate =>
            {
                if (excelDate < 1)
                    throw new ArgumentException("Excel dates cannot be smaller than 0.");
                if (excelDate > 60d)
                    excelDate = excelDate - 2;
                else
                    excelDate = excelDate - 1;
                return dateOfReference.AddDays(excelDate);
            });
            var tprops = (new T())
                .GetType()
                .GetProperties()
                .ToList();
            var start = table.Address.Start;
            var end = table.Address.End;
            var cells = new List<ExcelRangeBase>();
            for (var r = start.Row; r <= end.Row; r++)
                for (var c = start.Column; c <= end.Column; c++)
                    cells.Add(table.WorkSheet.Cells[r, c]);

            var groups = cells
                .GroupBy(cell => cell.Start.Row)
                .ToList();
            var types = groups
                .Skip(1)
                .First()
                .Select(rcell => rcell.Value != null ? rcell.Value.GetType() : null)
                .ToList();
            var colnames = groups
                .First()
                .Select((hcell, idx) => new { Name = Mapper.Map(hcell.Value), index = idx })
                .Where(o => tprops.Select(p => p.Name).Contains(o.Name))
                .ToList();
            var rowvalues = groups
                .Skip(1)
                .Select(cg => cg.Select(c => c.Value).ToList());
            var collection = rowvalues
                .Select(row =>
                {
                    var tnew = new T();
                    colnames.ForEach(colname =>
                    {
                        var val = row[colname.index];
                        var type = types[colname.index];
                        var prop = tprops.First(p => p.Name == colname.Name);
                        if (type == typeof(double))
                        {
                            if (!string.IsNullOrWhiteSpace(val?.ToString()))
                            {
                                var unboxedVal = (double)val;
                                if (prop.PropertyType == typeof(Int32))
                                    prop.SetValue(tnew, (int)unboxedVal);
                                else if (prop.PropertyType == typeof(double))
                                    prop.SetValue(tnew, unboxedVal);
                                else if (prop.PropertyType == typeof(DateTime))
                                    prop.SetValue(tnew, convertDateTime(unboxedVal));
                                else
                                    throw new NotImplementedException(String.Format("Type '{0}' not implemented yet!", prop.PropertyType.Name));
                            }
                        }
                        else
                        {
                            prop.SetValue(tnew, val);
                        }
                    });

                    return tnew;
                });
            return collection;
        }
    }
}
