using System.ComponentModel.DataAnnotations;

namespace TestTask.Repository.Items
{
    public class RoleItem
    {
        [Key]
        public int RoleId { get; set; }
        
        public string Name { get; set; }
    }
}