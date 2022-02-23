using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Services
{
    public class GeneratorFactory : IGeneratorFactory
    {
        public IGenerator CreateMessageGenerator(UserModel userModel, List<NewsModel> newsModels)
        {
            switch (userModel.RoleName)
            {
                case "Admin": return new AdminMessageGenerator(newsModels, userModel);
                default: return new UserMessageGenerator(newsModels, userModel); 
            }
        }
    }
}
