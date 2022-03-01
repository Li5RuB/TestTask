using NewsParser.Services.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Services
{
    public interface IGeneratorService
    {
        public List<Message> GenerateMessages(List<UserModel> userModels,ConcurrentStack<Message> messages);
    }
}
