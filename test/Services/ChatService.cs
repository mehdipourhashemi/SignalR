using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.DB_Context;
using test.Interface;
using test.Models.MessageModel;
using test.Utilities;
using test.ViewModels;

namespace test.Services
{
    public class ChatService : IChatService
    {
        private readonly chatDBContext db;

        public ChatService(chatDBContext _db)
        {
            this.db = _db;
        }

        public async Task<ResultDto<List<MessageDto>>> LoadMessages(Guid userid, Guid TargetUserId, int PageNumber, int pageCount)
        {
            try
            {
                var messages = db.messages.Where(m =>
            (m.ReceiverUserId == userid && m.SenderUserId == TargetUserId) ||
            (m.ReceiverUserId == TargetUserId && m.SenderUserId == userid)).Select(m => new MessageDto
            {
                Id = m.Id,
                Text = m.Text,
                IsRead = m.IsRead,
                IsReceived = m.IsReceived,
                Time = m.Time,
                IsReceivedMessage = m.ReceiverUserId == userid ? true : false,
                UniqId = m.UniqId,
            }).OrderByDescending(m => m.Time).Skip((PageNumber-1)*pageCount).Take(pageCount).OrderBy(m => m.Time).ToList();

                return new ResultDto<List<MessageDto>>() { Data = messages };
            }
            catch(Exception e)
            {
                return new ResultDto<List<MessageDto>>() { IsSuccess = false, Message = e.Message, };
            }
        }

        public async Task<ResultDto<List<UserDto>>> LoadUsers()
        {
            try
            {
                var users = db.users.Select(u => new UserDto
                {
                    Id = u.Id,
                    FullName = u.FirstName + " " + u.LastName,
                    UserName = u.UserName,
                    IsOnline = u.IsOnline,
                }).OrderByDescending(u => u.IsOnline).ToList();

                var users2 = db.users.Select(u => new UserDto { 
                    Id = u.Id,
                    MessageCount = u.SendMessages.Where(m => m.ReceiverUserId == u.Id).Count()
                }).ToList();

                //var users2 = (from u in db.users
                //             join m in db.messages on u.Id equals m.ReceiverUserId
                //             where m.IsRead == false
                //             group m.ReceiverUserId by new { u.Id , u.FirstName, u.LastName, u.IsOnline} into g
                             
                //             select new UserDto()
                //             {
                //                 Id = g.Key.Id,
                //                 MessageCount = g.Count(),
                //                 FullName = g.Key.FirstName + " " + g.Key.LastName,
                //                 IsOnline = g.Key.IsOnline
                //             }).ToList();

                return new ResultDto<List<UserDto>> { Data = users };
            }
            catch(Exception e)
            {
                return new ResultDto<List<UserDto>> { IsSuccess = false, Message = e.Message };
            }
        }
    }
}
