using Microsoft.AspNetCore.SignalR;
using System.Linq;

namespace Aspo.Api.Services
{
    public class MyIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User.Claims.First(c => c.Type == "UserId").Value;
        }
    }
}
