using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public interface IHashSettings
    {
        public int SaltSize { get; set; }

        public int HashSize { get; set; }
        
        public int Iterations { get; set; }
    }
}
