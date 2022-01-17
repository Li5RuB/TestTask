using Task.Services.Models;

namespace Task.Web.Models
{
    public class ViewModelUser
    {
        public ViewModelUser(UserModel user, TitleModel title, CityModel city, CountryModel country)
        {
            UserId = user.UserId;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            Phone = user.Phone;
            Comments = user.Comments;
            TitleId = user.TitleId;
            Title = title;
            CityId = user.CityId;
            City = city;
            Country = country;
        }

        public int UserId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Comments { get; set; }

        public int TitleId { get; set; }

        public TitleModel Title { get; set; }

        public int CityId { get; set; }

        public CityModel City { get; set; }

        public CountryModel Country { get; set; }
    }
}
