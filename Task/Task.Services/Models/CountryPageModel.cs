using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class CountryPageModel
    {
        public CountryPageModel(List<CountryModel> userModel, int pageCount, int currentPage)
        {
            CountryModels = userModel;
            PageCount = pageCount;
            CurrentPage = currentPage;
        }

        public List<CountryModel> CountryModels { get; set; }

        public int PageCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
