using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;

namespace Task.Services.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set;}

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Comments { get; set; }

        public int TitleId { get; set; }

        public int CityId { get; set; }
    }
}
