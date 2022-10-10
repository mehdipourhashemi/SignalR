using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.DB_Context;
using test.Interface;
using test.Models.UserModel;
using test.Utilities;
using test.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace test.Services
{
    public class MyAuthService : IMyAuthService
    {
        private readonly chatDBContext db;
        private readonly IMemoryCache memoryCache;
        

        public MyAuthService(chatDBContext db, IMemoryCache _memoryCache)
        {
            this.db = db;
            this.memoryCache = _memoryCache;
        }
        public async Task<ResultDto<bool>> AddUser(UserDto model)
        {
            var encrypt = new EncryptionUtility();
            try
            {
                if (model.UserName == null || model.UserName.Length < 5) { }
                if (model.password == null) { }
                if (model.password != model.ConfirmPassword) { throw new Exception("رمز عبور با تکرار آن مطابقت ندارد!"); }
                var salt = encrypt.GetNewSalt();
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    //BirthDate = DateUtility.JalaliToMiladi(model.JalaliBirthDate),
                    CreatedDate = DateTime.Now,
                    PasswordSalt = salt,
                    PasswordHash = encrypt.GetSHA256(model.password, salt)
                };
                await db.users.AddAsync(user);
                await db.SaveChangesAsync();
                return new ResultDto<bool> { IsSuccess = true, Message = "با موفقیت ثبت شد" };
            }
            catch (Exception e)
            {
                return new ResultDto<bool> { IsSuccess = false, Message = e.Message };
            }

        }

        public async Task<UserDto> GetUserToken(UserDto model)
        {
            var encrypt = new EncryptionUtility();
            var user =  db.users.Where(u => u.UserName == model.UserName).FirstOrDefault();
            string passwordHash = "";
            UserDto result = new UserDto();

            if (user == null)
            {
                return null;
            }
            passwordHash = encrypt.GetSHA256(model.password, user.PasswordSalt);
            if (passwordHash == user.PasswordHash)
            {
                result.UserName = user.UserName;
                result.Token = encrypt.GetNewToken(user.Id, user.FirstName, user.LastName, user.UserName);
                result.RefreshToken = encrypt.GetNewRefreshToken();
                return result;
            }
            return null;
        }
        public  ResultDto<UserDto> GetUserById(Guid id)
        {
            try
            {
                var user =  db.users.Where(u=>u.Id == id).FirstOrDefault();
                ResultDto<UserDto> response = new ResultDto<UserDto>() {
                    Data = new UserDto(),
                };
                if (user != null)
                {
                    response.Data.Id = user.Id;
                    response.Data.ConnectionId = user.ConnectionId;
                    response.Data.FirstName = user.FirstName;
                    response.Data.LastName = user.LastName;
                    return response;
                }
                else
                {
                    throw new Exception("user Not Found");
                }
            }
            catch(Exception e)
            {
                return new ResultDto<UserDto>() { IsSuccess = false, Message = e.Message };
            }

        }

        public async Task<ResultDto<string>> GetConnectionIdByuserId(Guid id)
        {
            try
            {
                var cacheKey = $"connectionid_{id}";
                string cacheValue;
                if (!memoryCache.TryGetValue(cacheKey, out cacheValue))
                {
                    var user = await db.users.FindAsync(id);
                    if (user != null)
                    {
                        cacheValue = user.ConnectionId;
                        var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
                        memoryCache.Set(cacheKey, user.ConnectionId, cacheEntryOptions);
                    }
                    else
                    {
                        throw new Exception("user Not Found");
                    }
                }
                return new ResultDto<string> { Data = cacheValue };
            }
            catch(Exception e)
            {
                return new ResultDto<string> { IsSuccess = false, Message = e.Message };
            }
        }
    }
}
