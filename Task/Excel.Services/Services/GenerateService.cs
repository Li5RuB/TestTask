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
            using (var p = new ExcelPackage(new FileInfo(_formPath)))
            {
                p.Workbook.Worksheets[0].Drawings.Remove(0);
                foreach (var item in excelData)
                {
                    string name = CinfigureName(item);
                    var ws = p.Workbook.Worksheets.Copy(p.Workbook.Worksheets[0].Name, name);
                    FillCells(item, ws);
                    FixeChart(name, ws);
                }
                p.Workbook.Worksheets.Delete(0);
                if (!Directory.Exists(_resultPath))
                {
                    Directory.CreateDirectory(_resultPath.Replace("Forms",""));
                }
                p.SaveAs(_resultPath + DateTime.Now.ToString("dd.MM.yyyy.HH.mm") + ".xlsx");
            }
        }

        private static string CinfigureName(ExcelData item)
        {
            var namem = item.Name.Split(' ');
            var name = namem[0] + namem[1];
            return name;
        }

        private static void FixeChart(string name, ExcelWorksheet ws)
        {
            ((ExcelChart)ws.Drawings[3]).ChartXml.InnerXml = ((ExcelChart)ws.Drawings[3]).ChartXml.InnerXml.Replace("Лист1", name);
            ((ExcelChart)ws.Drawings[1]).ChartXml.InnerXml = ((ExcelChart)ws.Drawings[1]).ChartXml.InnerXml.Replace("Лист1", name);
        }

        private static void FillCells(ExcelData item, ExcelWorksheet ws)
        {
            FillHeaders(item, ws);
            FillTablesBody(item, ws);
            SetUpFormulas(ws);
        }

        private static void FillTablesBody(ExcelData item, ExcelWorksheet ws)
        {
            ws.Cells["D9"].Value = item.Squatting;
            ws.Cells["D10"].Value = item.SteppingOverL;
            ws.Cells["D11"].Value = item.SteppingOverPR;
            ws.Cells["D12"].Value = item.LungeL;
            ws.Cells["D13"].Value = item.LungePR;
            ws.Cells["D14"].Value = item.ShoulderMobilityL;
            ws.Cells["D15"].Value = item.ShoulderMobilityPR;
            ws.Cells["D16"].Value = item.StraightLegRaiseL;
            ws.Cells["D17"].Value = item.StraightLegRaisePR;
            ws.Cells["D18"].Value = item.PushUps;
            ws.Cells["D19"].Value = item.RotationalStabilityL;
            ws.Cells["D20"].Value = item.RotationalStabilityPR;
        }

        private static void FillHeaders(ExcelData item, ExcelWorksheet ws)
        {
            ws.Cells["C3"].Value = item.Name;
            ws.Cells["H3"].Value = item.Growth;
            ws.Cells["H4"].Value = item.Weight;
            ws.Cells["H5:H6"].Merge = true;
            ws.Cells["H5"].Value = item.Sex;
            ws.Cells["L5"].Value = item.Date;
        }

        private static void SetUpFormulas(ExcelWorksheet ws)
        {
            ws.Cells["G21"].ClearFormulas();
            ws.Cells["G21"].Formula = "SUM(F9:F20)/7";
            ws.Cells["F9:F19"].ClearFormulas();
            ws.Cells["F9"].Formula = "D9";
            ws.Cells["F10"].Formula = "MIN(D10:E11)";
            ws.Cells["F12"].Formula = "MIN(D12:E13)";
            ws.Cells["F14"].Formula = "MIN(D14:E15)";
            ws.Cells["F16"].Formula = "MIN(D16:E17)";
            ws.Cells["F18"].Formula = "D18";
            ws.Cells["F19"].Formula = "MIN(D19:E20)";
        }
    }
}
