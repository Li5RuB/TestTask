using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Services.Services
{
    public interface IGenerateService
    {
        public void GenerateForms(List<ExcelData> excelData);
    }
}
