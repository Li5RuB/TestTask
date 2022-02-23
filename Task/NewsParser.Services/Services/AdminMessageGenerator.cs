using NewsParser.Services.Models;
using System.Collections.Generic;
using System.Text;

namespace NewsParser.Services.Services
{
    public class AdminMessageGenerator : IGenerator
    {
        private List<NewsModel> _newsModels;
        private readonly UserModel _userModel;

        public AdminMessageGenerator(List<NewsModel> newsModels, UserModel userModel)
        {
            _newsModels = newsModels;
            _userModel = userModel;
        }

        public Message CreateMessage()
        {
            return new Message(_userModel.Email, GenerateText());
        }

        private string GenerateText()
        {
            var message = new StringBuilder();
            message.AppendLine($"Привет admin {_userModel.Name}\n");
            foreach (var newsModel in _newsModels)
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
