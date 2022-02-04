using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class CityPageModel
    {
        public CityPageModel(List<CityModel> cityModels, int pageCount, int currentPage)
        {
            CityModels = cityModels;
            PageCount = pageCount;
            CurrentPage = currentPage;
        }

        public List<CityModel> CityModels { get; set; }

        public int PageCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
