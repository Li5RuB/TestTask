using NewsParser.Common.Settings;
using NewsParser.Repositories.Repositories;
using NewsParser.Services.Mappers;
using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Services
{
    public class SendService : ISendService
    {
        private readonly IGeneratorService _generatorService;
        private const string FilesPath = @"d:\Email\";

        public SendService(IGeneratorService generatorService)
        {
            _generatorService = generatorService;
        }

        public void SendMessages(List<Message> messages)
        {
            foreach (var item in messages)
            {
                if (!File.Exists(FilesPath))
                {
                    Directory.CreateDirectory(FilesPath);
                }
                using (FileStream fs = File.Create(FilesPath + item.Email + ".txt"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(item.Text);
                    fs.Write(info, 0, info.Length);
                }
            }
            
        }
    }
}
