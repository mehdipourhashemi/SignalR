using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models.MessageModel;
using test.ViewModels;

namespace test.Interface
{
    public interface IHubService
    {
        public Task<ResultDto<bool>> AddUserConnectionId(Guid userId, string connectionId);
        public Task<ResultDto<bool>> SendOneToOneMessage(Guid SenderUserId, Guid ReceiverUserId, string message);
        public Task OfflineUser(Guid userId);
        public Task<ResultDto<bool>> SaveMessage(Guid receiver, Guid sender, string message, Guid MessageId);
        public Task<ResultDto<MessageDto>> GetConnectionidByMessageId(Guid messageId);
        public Task<ResultDto<bool>> ReceiveMessage(Guid messageId);
        public Task<ResultDto<bool>> ReceiveMessage(List<Guid> messageIds);

    }
}
