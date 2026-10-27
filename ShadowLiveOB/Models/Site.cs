using System.ComponentModel.DataAnnotations;

namespace ShadowLiveOB.Models
{
    public class Site
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}