using NewsParser.Services.Models;
using System.Collections.Generic;
using System.Text;

namespace NewsParser.Services.Services
{
    public class AdminMessageGenerator : IGenerator
    {
        public Message CreateMessage(List<NewsModel> newsModels, UserModel userModel)
        {
            return new Message(userModel.Email, GenerateText(newsModels, userModel));
        }

        private string GenerateText(List<NewsModel> newsModels, UserModel userModel)
        {
            var message = new StringBuilder();
            message.AppendLine($"Привет admin {userModel.Name}\n");
            foreach (var newsModel in newsModels)
            {
                message.AppendLine($"{newsModel.Title}\n");
                message.AppendLine($"{newsModel.BriefContext}");
                message.AppendLine($"{newsModel.Date}");
                message.AppendLine("\n\n");
            }
            return message.ToString();
        }
    }
}
