using Excel.Services.Mappers;
using Excel.Services.Settings;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;

namespace Excel.Services.Services
{
    public class GenerateService : IGenerateService
    {
        private readonly string _resultPath;
        private readonly string _formPath;

        public GenerateService(IAppSettings appSettings)
        {
            _resultPath = appSettings.resultPath;
            _formPath = appSettings.formPath;
        }

        public void GenerateForms(List<ExcelData> excelData)
        {
            using (var packege = new ExcelPackage(new FileInfo(_formPath)))
            {
                packege.Workbook.Worksheets[0].Drawings.Remove(0);
                foreach (var item in excelData)
                {
                    string name = CinfigureName(item);
                    var worksheets = packege.Workbook.Worksheets.Copy(packege.Workbook.Worksheets[0].Name, name);
                    FillCells(item, worksheets);
                    FixeChart(name, worksheets);
                }
                packege.Workbook.Worksheets.Delete(0);
                if (!Directory.Exists(_resultPath))
                {
                    Directory.CreateDirectory(_resultPath.Replace("Forms",""));
                }
                packege.SaveAs(_resultPath + DateTime.Now.ToString("dd.MM.yyyy.HH.mm") + ".xlsx");
            }
        }

        private static string CinfigureName(ExcelData item)
        {
            var namem = item.Name.Split(' ');
            var name = namem[0] + namem[1];
            return name;
        }

        private static void FixeChart(string name, ExcelWorksheet worksheets)
        {
            ((ExcelChart)worksheets.Drawings[3]).ChartXml.InnerXml = ((ExcelChart)worksheets.Drawings[3]).ChartXml.InnerXml.Replace("Лист1", name);
            ((ExcelChart)worksheets.Drawings[1]).ChartXml.InnerXml = ((ExcelChart)worksheets.Drawings[1]).ChartXml.InnerXml.Replace("Лист1", name);
        }

        private static void FillCells(ExcelData item, ExcelWorksheet worksheets)
        {
            FillHeaders(item, worksheets);
            FillTablesBody(item, worksheets);
            SetUpFormulas(worksheets);
        }

        private static void FillTablesBody(ExcelData item, ExcelWorksheet worksheets)
        {
            worksheets.Cells["D9"].Value = item.Squatting;
            worksheets.Cells["D10"].Value = item.SteppingOverL;
            worksheets.Cells["D11"].Value = item.SteppingOverPR;
            worksheets.Cells["D12"].Value = item.LungeL;
            worksheets.Cells["D13"].Value = item.LungePR;
            worksheets.Cells["D14"].Value = item.ShoulderMobilityL;
            worksheets.Cells["D15"].Value = item.ShoulderMobilityPR;
            worksheets.Cells["D16"].Value = item.StraightLegRaiseL;
            worksheets.Cells["D17"].Value = item.StraightLegRaisePR;
            worksheets.Cells["D18"].Value = item.PushUps;
            worksheets.Cells["D19"].Value = item.RotationalStabilityL;
            worksheets.Cells["D20"].Value = item.RotationalStabilityPR;
        }

        private static void FillHeaders(ExcelData item, ExcelWorksheet worksheets)
        {
            worksheets.Cells["C3"].Value = item.Name;
            worksheets.Cells["H3"].Value = item.Growth;
            worksheets.Cells["H4"].Value = item.Weight;
            worksheets.Cells["H5:H6"].Merge = true;
            worksheets.Cells["H5"].Value = item.Sex;
            worksheets.Cells["L5"].Value = item.Date;
        }

        private static void SetUpFormulas(ExcelWorksheet worksheets)
        {
            worksheets.Cells["G21"].ClearFormulas();
            worksheets.Cells["G21"].Formula = "SUM(F9:F20)/7";
            worksheets.Cells["F9:F19"].ClearFormulas();
            worksheets.Cells["F9"].Formula = "D9";
            worksheets.Cells["F10"].Formula = "MIN(D10:E11)";
            worksheets.Cells["F12"].Formula = "MIN(D12:E13)";
            worksheets.Cells["F14"].Formula = "MIN(D14:E15)";
            worksheets.Cells["F16"].Formula = "MIN(D16:E17)";
            worksheets.Cells["F18"].Formula = "D18";
            worksheets.Cells["F19"].Formula = "MIN(D19:E20)";
        }
    }
}
