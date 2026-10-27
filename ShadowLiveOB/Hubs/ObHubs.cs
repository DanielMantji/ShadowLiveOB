using Microsoft.AspNetCore.SignalR;

namespace ShadowLiveOB.Hubs
{
    public class ObHub : Hub
    {
        public async Task SendNewLog(string guardName, string message)
        {
            await Clients.All.SendAsync("ReceiveLog", guardName, message, DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}