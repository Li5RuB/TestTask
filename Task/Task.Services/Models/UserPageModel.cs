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
        public UserPageModel(List<UserModel> userModel, int pageCount, int currentPage)
        {
            this.UserModels = userModel;
            this.pageCount = pageCount;
            this.currentPage = currentPage;
        }

        public List<UserModel> UserModels { get; set; }

        public int pageCount { get; set; }

        public int currentPage { get; set; }
    }
}
