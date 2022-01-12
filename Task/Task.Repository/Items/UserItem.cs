using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository.Items
{
    public class UserItem
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set;}
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public int TitleId { get; set; }

        public TitleItem Title { get;set; }

        public string Comments { get; set; }

        public int CityId { get; set; }

        public CityItem City { get; set; }
    }
}
