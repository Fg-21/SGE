using Microsoft.AspNetCore.SignalR;
using SignalRChat.Entities;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}