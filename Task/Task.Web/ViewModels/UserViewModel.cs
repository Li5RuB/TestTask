using Task.Services.Models;

namespace Task.Web.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(UserModel userModel)
        {
            Id = userModel.Id;
            Name = $"{userModel.Firstname} {userModel.Lastname}";
            Email = userModel.Email;
            Country = userModel.City.Country.Name;
            City = userModel.City.Name;
            Phone = userModel.Phone;
        }

        public int Id { get; set; }

        public string Name { get; set;}
        
        public string Email { get; set;}

        public string Country { get; set;}

        public string City { get; set;}

        public string Phone { get; set;}
    }
}
