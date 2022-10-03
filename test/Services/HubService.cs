using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test.DB_Context;
using test.Interface;
using test.Models.MessageModel;
using test.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace test.Services
{
    public class HubService : IHubService
    {
        private readonly chatDBContext db;
        private readonly IMemoryCache memoryCache;
        public HubService(chatDBContext _db, IMemoryCache _memoryCache)
        {
            this.db = _db;
            this.memoryCache = _memoryCache;
        }
        public async Task<ResultDto<bool>> AddUserConnectionId(Guid userId, string connectioId)
        {
            try
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
                var cacheKey = $"connectionid_${userId}";
                memoryCache.Set(cacheKey, connectioId , cacheEntryOptions);

                var user = await db.users.FindAsync(userId);
                if (user != null)
                {
                    user.ConnectionId = connectioId;
                    user.IsOnline = true;
                    db.Update(user);
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("user Not Found");
                }
                return new ResultDto<bool>();
            }
            catch(Exception e)
            {
                return new ResultDto<bool> { IsSuccess = false, Message = e.Message, };
            }
            
        }

        public async Task OfflineUser(Guid userId)
        {
            var user = await db.users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            if(user != null)
            {
                user.IsOnline = false;
                db.Update(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<ResultDto<bool>> SendOneToOneMessage(Guid SenderUserId, Guid ReceiverUserId, string messageText)
        {
            try
            {
                var message = new Message()
                {
                    Text = messageText,
                    ReceiverUserId = ReceiverUserId,
                    SenderUserId = SenderUserId,
                    Time = DateTime.Now,
                    IsRead = false,
                    IsReceived = false,
                };
                await db.messages.AddAsync(message);
                await db.SaveChangesAsync();
                return new ResultDto<bool>() { };
            }
            catch(Exception e)
            {
                return new ResultDto<bool>() { IsSuccess = false, Message = e.Message };
            }
        }
        public async Task<ResultDto<bool>> SaveMessage(Guid receiver, Guid sender, string MessageText, Guid messageId)
        {
            try
            {
                var message = new Message()
                {
                    ReceiverUserId = receiver,
                    SenderUserId = sender,
                    Text = MessageText,
                    Time = DateTime.Now,
                    UniqId= messageId
                };
                await db.messages.AddAsync(message);
                await db.SaveChangesAsync();
                return new ResultDto<bool> { };
            }
            catch(Exception e)
            {
                return new ResultDto<bool> { IsSuccess = false, Message = e.Message, };
            }
        }

        public async Task<ResultDto<MessageDto>> GetConnectionidByMessageId(Guid messageId)
        {
            try
            {
                var message = await db.messages.Where(m => m.UniqId == messageId)
                .Select(m => new MessageDto()
                {
                    ConnectionId = m.SenderUser.ConnectionId,
                }).FirstOrDefaultAsync();

                if (message == null)
                {
                    
                    throw new Exception("پیام یافت نشد");
                }
                else
                {
                    return new ResultDto<MessageDto>() { Data = message };
                }
            }
            catch(Exception e)
            {
                return new ResultDto<MessageDto> { IsSuccess = false, Message = e.Message };
            }
        }

        public async Task<ResultDto<bool>> ReceiveMessage(List<Guid> messageIds)
        {
            try
            {
                var message = db.messages.Where(m => messageIds.Contains(m.UniqId) && m.IsReceived == false);
                if (message != null)
                {
                    await message.ForEachAsync(m => m.IsReceived = true);
                    await db.SaveChangesAsync();
                    return new ResultDto<bool>() { };
                }
                else
                {
                    throw new Exception("پیام یافت نشد");
                }
            }
            catch(Exception e)
            {
                return new ResultDto<bool> { IsSuccess = false, Message = e.Message };
            }
            
        }

        public async Task<ResultDto<bool>> ReceiveMessage(Guid messageId)
        {
            try
            {
                var message = db.messages.Where(m => m.UniqId == messageId).FirstOrDefault();
                if (message != null)
                {
                    message.IsReceived = true;
                    await db.SaveChangesAsync();
                    return new ResultDto<bool>() { };
                }
                else
                {
                    throw new Exception("پیام یافت نشد");
                }
            }
            catch (Exception e)
            {
                return new ResultDto<bool> { IsSuccess = false, Message = e.Message };
            }

        }
    }
}
