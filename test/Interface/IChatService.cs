using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models.MessageModel;
using test.ViewModels;

namespace test.Interface
{
    public interface IChatService
    {
        public Task<ResultDto<List<UserDto>>> LoadUsers();
        public Task<ResultDto<List<MessageDto>>> LoadMessages(Guid userid, Guid TargetUserId, int PageNumber, int PageCount);
    }
}
