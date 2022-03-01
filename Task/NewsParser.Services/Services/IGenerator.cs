using NewsParser.Services.Models;
using System.Collections.Generic;

namespace NewsParser.Services.Services
{
    public interface IGenerator
    {
        public Message CreateMessage(List<NewsModel> newsModels, UserModel userModel);
    }
}