using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Services.Settings
{
    public interface IAppSettings
    {
        public string formPath { get; set; }

        public string protocolPath { get; set; }

        public string resultPath { get; set; }
    }
}
