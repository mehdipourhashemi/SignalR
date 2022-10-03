using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using test.Interface;
using test.Utilities;

namespace test.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IHubService hubService;
        private readonly IMyAuthService authService;

        public ChatHub(IHubService hubService, IMyAuthService authService)
        {
            this.hubService = hubService;
            this.authService = authService;
        }
        public override async Task OnConnectedAsync()
        {
            var userid = new EncryptionUtility().UserInfo(Context).Id;
            await hubService.AddUserConnectionId(userid, Context.ConnectionId);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = new EncryptionUtility().UserInfo(Context);
            await hubService.OfflineUser(user.Id);
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessageToOne(string message, Guid messageId, Guid userId)
        {
            var SenderUser = new EncryptionUtility().UserInfo(Context);
            //var RecieverUser = authService.GetUserById(userId);
            var RecieverUser = await authService.GetConnectionIdByuserId(userId);
            if (RecieverUser.Data != null && SenderUser != null)
            {
                await hubService.SaveMessage(userId, SenderUser.Id , message, messageId);

                await Clients.Caller.SendAsync("DeliveryMessageInServer", messageId);

                await Clients.Clients(RecieverUser.Data).SendAsync("ReceiveMessage",
                    SenderUser.Id,
                    message,
                    messageId);
            }
        }
        public async Task DeliveryMessageInClient(Guid messageId)
        {
            var message = await hubService.GetConnectionidByMessageId(messageId);
            if (message.IsSuccess)
            {
                await hubService.ReceiveMessage(messageId);
                await Clients.Client(message.Data.ConnectionId).SendAsync("SentMessageToClient", messageId);
            }
        }
        public async Task DeliveryMessageInClientList(List<Guid> messageIds)
        {
            await hubService.ReceiveMessage(messageIds);
            //var message = await hubService.GetConnectionidByMessageId(messageIds[0]);
            //await Clients.Client(message.Data.ConnectionId).SendAsync("SentMessageToClient", message.Data);
        }
    }
}
