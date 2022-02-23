using NewsParser.Services.Models;

namespace NewsParser.Services.Services
{
    public interface IGenerator
    {
        public Message CreateMessage();
    }
}