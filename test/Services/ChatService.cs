using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test.DB_Context;
using test.Interface;
using test.Models.MessageModel;
using test.Models.UserModel;
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

        public async Task<ResultDto<bool>> AddContact(Contact model)
        {
            var result = new ResultDto<bool>();
            try
            {
               
                if (db.users.Where(u => u.Id == model.FollowingUserId).Count() == 0)
                {
                    throw new Exception("user not Founded");
                }
                if (db.contacts.Where(c => c.FollowerUserId == model.FollowerUserId && c.FollowingUserId == model.FollowingUserId).Count() > 0)
                {
                    throw new Exception("user is in contact");
                }
                var contact = new Contact()
                {
                    FollowingUserId = model.FollowingUserId,
                    FollowerUserId = model.FollowerUserId,
                    Time = DateTime.Now,
                };
                await db.contacts.AddAsync(contact);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        public async Task<ResultDto<bool>> DeleteContact(Contact model)
        {
            var result = new ResultDto<bool>();
            try
            {
                
                var contact = db.contacts.Where(c => c.FollowerUserId == model.FollowerUserId && c.FollowingUserId == model.FollowingUserId);
                await contact.ForEachAsync(c => db.contacts.Remove(c));
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
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
            }).OrderByDescending(m => m.Time).Skip((PageNumber - 1) * pageCount).Take(pageCount).OrderBy(m => m.Time).ToList();

                return new ResultDto<List<MessageDto>>() { Data = messages };
            }
            catch (Exception e)
            {
                return new ResultDto<List<MessageDto>>() { IsSuccess = false, Message = e.Message, };
            }
        }

        public async Task<ResultDto<List<UserDto>>> LoadUsers(Guid userid)
        {
            try
            {
                var users2 = await db.contacts.Where(c => c.FollowerUserId == userid)
                    .Select(c => new UserDto()
                    {
                        Id = c.FollowingUser.Id,
                        FullName = c.FollowingUser.FirstName + " " + c.FollowingUser.LastName,
                        UserName = c.FollowingUser.UserName,
                        IsOnline = c.FollowingUser.IsOnline,
                    }).ToListAsync();


                return new ResultDto<List<UserDto>> { Data = users2 };
            }
            catch (Exception e)
            {
                return new ResultDto<List<UserDto>> { IsSuccess = false, Message = e.Message };
            }
        }

        public async Task<ResultDto<List<UserDto>>> SearchUser(UserDto model)
        {
            var result = new ResultDto<List<UserDto>>();
            try
            {
                var user = await db.users.Where(u => u.UserName.Contains(model.UserName) && u.Id != model.FollowerUserId).Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FullName = u.FirstName + " " + u.LastName,
                    IsInContact = u.FollowingUsers.Where(c => c.FollowerUserId == model.FollowerUserId).Count() > 0 ? true : false,

                }).ToListAsync();

                //var user2 = await (from u in db.users
                //             join c in db.contacts on u.Id equals c.FollowingUserId into contact
                //             from c2 in contact.Where(c => c.FollowerUserId == model.FollowerUserId)
                //             select new UserDto()
                //             {
                //                 Id = u.Id,
                //                 UserName = u.UserName,
                //                 FullName = u.FirstName + " " + u.LastName,
                //                 IsInContact = c2.Id == null ? false : true,
                //             }).ToListAsync();

                if (user.Count() > 0)
                {
                    result.Data = user;
                }
                else
                {
                    throw new Exception("user not fount");
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
