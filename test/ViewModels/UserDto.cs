using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.ViewModels
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string JalaliBirthDate { get; set; }
        public string ConnectionId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool IsOnline { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageCount { get; set; } = 4;
        public int MessageCount { get; set; }
        public bool? IsInContact { get; set; }
        public Guid? FollowerUserId { get; set; }
        public Guid? FollowingUserId { get; set; }
        public int Page { get; set; } = 1;
        public int RowsPerPage { get; set; } = 50;
        public DateTime? FirstMessageTime { get; set; }

    }
}
