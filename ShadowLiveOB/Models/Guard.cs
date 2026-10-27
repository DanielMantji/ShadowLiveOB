using System.ComponentModel.DataAnnotations;

namespace ShadowLiveOB.Models
{
    public class Guard
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
    }
}