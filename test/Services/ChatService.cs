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
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using test.Models;

namespace test.Services
{
    public class ChatService : IChatService
    {
        private readonly chatDBContext db;
        private readonly string connectionString;

        public ChatService(chatDBContext _db, IConfiguration config)
        {
            this.db = _db;
            this.connectionString = config.GetConnectionString("default_dapper");
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

        public async Task<ResultDto<List<MessageDto>>> LoadMessage_LastMessageTime(Guid userid, Guid TargetUserId, int PageNumber, int PageCount, DateTime? time)
        {
            try
            {
                var messages = await db.messages.Where(m =>
            ((m.ReceiverUserId == userid && m.SenderUserId == TargetUserId) ||
            (m.ReceiverUserId == TargetUserId && m.SenderUserId == userid)) && m.Time < time).Select(m => new MessageDto
            {
                Id = m.Id,
                Text = m.Text,
                IsRead = m.IsRead,
                IsReceived = m.IsReceived,
                Time = m.Time,
                IsReceivedMessage = m.ReceiverUserId == userid ? true : false,
                UniqId = m.UniqId,
            }).OrderByDescending(m => m.Time).Take(PageCount).OrderBy(m => m.Time).ToListAsync();


            
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

                var user = await db.users.Where(u => u.UserName.Contains(model.UserName)/* && u.Id != model.FollowerUserId*/).Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FullName = u.FirstName + " " + u.LastName,
                    IsInContact = u.FollowingUsers.Any(c => c.FollowerUserId == model.FollowerUserId) ? true : false,

                }).Skip((model.Page-1)*model.RowsPerPage).Take(model.RowsPerPage).OrderBy(u => u.UserName).ToListAsync();

                //var user = await (from u in db.users
                //            join c in db.contacts on 
                //            new {u.Id, x = (Guid)model.FollowerUserId } equals 
                //            new { Id = c.FollowingUserId, x = (Guid)c.FollowerUserId } into contact
                //            from c2 in contact.DefaultIfEmpty()
                //            where (u.UserName.Contains(model.UserName) && u.Id != model.FollowerUserId)
                //                        select new UserDto()
                //            {
                //                Id = u.Id,
                //                UserName = u.UserName,
                //                FullName = u.FirstName + " " + u.LastName,
                //                IsInContact = c2.Id == null ? false : true,
                //            }).ToListAsync();

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
        public async Task<ResultDto<List<UserDto>>> SearchUser_dapper(UserDto model)
        {
            var result = new ResultDto<List<UserDto>>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = "dbo.search_user";
                    var param = new DynamicParameters();
                    param.Add("@pUserName", model.UserName);
                    param.Add("@pFollowerUserId", model.FollowerUserId);
                    param.Add("@pPageNumber", model.PageNumber);
                    param.Add("@pRowsPerPage", model.RowsPerPage);
                    var r = await connection.QueryAsync<UserDto>(sql, param, commandType: CommandType.StoredProcedure);
                    result.Data = r.ToList();
                }
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }
        public UsersWithFollowing GetAllUserWithFollowing()
        {
            using (IDbConnection connection =
                new SqlConnection(connectionString))
            {
                var query = @"select
                            UserName,
                            (
                            select
                            u.userName
                            from contacts c
                            JOIN users u ON c.followingUserId = u.Id
                            WHERE c.FollowerUserId = users.Id
                            for json path
                            ) as followings
                            from users users
                            for json path, root('users')";
                var users = connection.QuerySingle<string>(query, commandType: CommandType.Text);
                //users.ForEach(u => u.FollowingUsers = JsonSerializer.Deserialize<ICollection<Contact>>(u.JSONContacts));
                JsonSerializer.Deserialize<UsersWithFollowing>(users);
                return JsonSerializer.Deserialize<UsersWithFollowing>(users);
            }
        }
    }
}
