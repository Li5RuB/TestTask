using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NewsParser.Common.Settings
{
    public class AppSettings : IAppSettings    
    {
        public string OnlinerLink { get; set; }

        public string BobrLink { get; set; }

        public string LentaLink { get; set; }

        public int NumberOfThreads { get; set; }

        public string[] SitesForPars { get; set; }

        public IRepositorySettings RepositorySettings { get; set; }

        public void Initialize(IConfigurationRoot configuration)
        {
            configuration.GetSection(nameof(AppSettings)).Bind(this);
            RepositorySettings = configuration.GetSection(nameof(RepositorySettings)).Get<RepositorySettings>();
        }
    }
}
