using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GamesectionAPI.Hubs
{
    public class CounterHub:Hub
    {
        private static int count { get; set; } = 0;
        public async override Task OnConnectedAsync()
        {
            count++;
            await Clients.All.SendAsync("ReceiveClientCount",count);
            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            count--;
            await Clients.All.SendAsync("ReceiveClientCount", count);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
