using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Services.Models;

namespace TestTask.Services.Models
{
    public class UserPageModel
    {
        public UserPageModel()
        {
            
        }
        
        public UserPageModel(List<UserModel> userModel, int pageCount, int currentPage)
        {
            UserModels = userModel;
            PageCount = pageCount;
            CurrentPage = currentPage;
        }
        
        public List<UserModel> UserModels { get; set; }
        
        public int PageCount { get; set; }
        
        public int CurrentPage { get; set; }
        
        public Dictionary<string, string> Sort {get; set; }
        
        public string Search { get; set; }
    }
}