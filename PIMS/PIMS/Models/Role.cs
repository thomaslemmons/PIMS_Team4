using System.ComponentModel.DataAnnotations;

namespace PIMS.Models
{
    public class RoleMod
    {
        [Key]
        public int ID { get; set; } 
        public string Email { get; set; }
        public int Role { get; set; }
    }
}
