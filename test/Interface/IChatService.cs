using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models.MessageModel;
using test.Models.UserModel;
using test.ViewModels;

namespace test.Interface
{
    public interface IChatService
    {
        public Task<ResultDto<List<UserDto>>> LoadUsers(Guid userid);
        public Task<ResultDto<List<MessageDto>>> LoadMessages(Guid userid, Guid TargetUserId, int PageNumber, int PageCount);
        public Task<ResultDto<List<MessageDto>>> LoadMessage_LastMessageTime(Guid userid, Guid TargetUserId, int PageNumber, int PageCount, DateTime? time );
        public Task<ResultDto<List<UserDto>>> SearchUser(UserDto user);
        public Task<ResultDto<bool>> AddContact(Contact model);
        public Task<ResultDto<bool>> DeleteContact(Contact model);
        public Task<ResultDto<List<UserDto>>> SearchUser_dapper(UserDto model);
    }
}
