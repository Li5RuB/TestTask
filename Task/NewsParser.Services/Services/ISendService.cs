using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Services
{
    public interface ISendService
    {
        public void SendMessages(List<Message> messages);
    }
}
