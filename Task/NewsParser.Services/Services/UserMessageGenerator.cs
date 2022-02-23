using NewsParser.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsParser.Services.Services
{
    public class UserMessageGenerator : IGenerator
    {
        private List<NewsModel> _newsModels;
        private readonly UserModel _userModel;

        public UserMessageGenerator(List<NewsModel> newsModels, UserModel userModel)
        {
            _newsModels = newsModels;
            _userModel = userModel;
        }

        public Message CreateMessage()
        {
            var newsForUser = _newsModels.FirstOrDefault(n=>n.Date == _newsModels.Max(n => n.Date));
            return new Message(_userModel.Email, GenerateText(newsForUser));
        }

        private string GenerateText(NewsModel newsModel)
        {
            var message = new StringBuilder();
            message.AppendLine($"Привет {_userModel.Name}\n");
            message.AppendLine($"{newsModel.Title}");
            message.AppendLine($"{newsModel.BriefContext}");
            message.AppendLine($"{newsModel.Date}");
            return message.ToString();
        }
    }
}
