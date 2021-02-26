using Aspo.Core.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace Aspo.Api.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub : Hub
    {
        private ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string receiveId, string content)
        {
            string senderId = Context.User.Claims.First(c => c.Type == "UserId").Value;
            //Message newMessage = new Message()
            //{
            //    SenderId = int.Parse(senderId),
            //    ReceiveId = int.Parse(receiveId),
            //    Content = content,
            //    CreateAt = DateTime.UtcNow
            //};
            //_dbContext.Messages.Add(newMessage);
            //await _dbContext.SaveChangesAsync();


            //await Clients.Users(senderId, receiveId).SendAsync("ReceiveMessage", newMessage);
            //await Clients.All.SendAsync("ReceiveMessage", newMessage);
            //await Clients.User(receiveId).SendAsync("ReceiveMessage", newMessage);

        }

    }
}
