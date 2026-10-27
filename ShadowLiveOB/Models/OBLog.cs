using System.ComponentModel.DataAnnotations;

namespace ShadowLiveOB.Models
{
    public class ObLog
    {
        [Key]
        public int Id { get; set; }
        public string GuardName { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string SiteName { get; set; } = "Main Site";
        public string CheckpointType { get; set; } = "Radio"; // Radio or NFC
    }
}