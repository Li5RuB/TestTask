using Microsoft.Extensions.DependencyInjection;
using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsParser.Common.Enums;

namespace NewsParser.Services.Services
{
    public class GeneratorFactory : IGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public GeneratorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IGenerator CreateMessageGenerator(string roleName)
        {
            switch (Enum.Parse<Roles>(roleName))
            {
                case Roles.Admin: return _serviceProvider.GetServices<IGenerator>().First(s=> s is AdminMessageGenerator);
                default: return _serviceProvider.GetServices<IGenerator>().First(s=>s is UserMessageGenerator); 
            }
        }
    }
}
