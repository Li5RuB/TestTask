using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Common.Settings
{
    public interface IRepositorySettings
    {
        public string TestTaskConnectionString { get; set; }
    }
}
