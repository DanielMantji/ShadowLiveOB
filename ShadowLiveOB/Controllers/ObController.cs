using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ShadowLiveOB.Hubs;
using ShadowLiveOB.Models;

namespace ShadowLiveOB.Controllers
{
    public class ObController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHubContext<ObHub> _hub;

        public ObController(ApplicationDbContext db, IHubContext<ObHub> hub)
        {
            _db = db;
            _hub = hub;
        }

        public IActionResult Index()
        {
            var logs = _db.ObLogs.OrderByDescending(x => x.Timestamp).Take(100).ToList();
            return View(logs);
        }

        [HttpPost]
        public async Task<IActionResult> PostLog(string guardName, string message, string checkpointType = "Radio")
        {
            var log = new ObLog
            {
                GuardName = guardName,
                Message = message,
                CheckpointType = checkpointType,
                Timestamp = DateTime.Now
            };

            _db.ObLogs.Add(log);
            _db.SaveChanges();

            // This makes it LIVE on all dashboards
            await _hub.Clients.All.SendAsync("ReceiveLog", guardName, message, DateTime.Now.ToString("HH:mm:ss"));

            return Ok("Logged");
        }
    }
}