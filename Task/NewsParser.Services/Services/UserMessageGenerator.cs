using NewsParser.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsParser.Services.Services
{
    public class UserMessageGenerator : IGenerator
    {
        public Message CreateMessage(List<NewsModel> newsModels, UserModel userModel)
        {
            var newsForUser = newsModels.FirstOrDefault(n=>n.Date == newsModels.Max(n => n.Date));
            return new Message(userModel.Email, GenerateText(newsForUser, userModel));
        }

        private string GenerateText(NewsModel newsModel, UserModel userModel)
        {
            var message = new StringBuilder();
            message.AppendLine($"Привет {userModel.Name}\n");
            message.AppendLine($"{newsModel.Title}");
            message.AppendLine($"{newsModel.BriefContext}");
            message.AppendLine($"{newsModel.Date}");
            return message.ToString();
        }
    }
}
