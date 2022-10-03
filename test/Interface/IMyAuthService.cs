using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.ViewModels;

namespace test.Interface
{
    public interface IMyAuthService
    {
        public Task<ResultDto<bool>> AddUser(UserDto model);
        public Task<UserDto> GetUserToken(UserDto model);
        public ResultDto<UserDto> GetUserById(Guid id);
        public Task<ResultDto<string>> GetConnectionIdByuserId(Guid id);
    }
}
