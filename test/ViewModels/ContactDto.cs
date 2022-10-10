using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models.UserModel
{
    public class ContactDto
    {
        public int Id { get; set; }
        public virtual User FollowerUser { get; set; }
        public virtual User FollowingUser { get; set; }
        public Guid FollowerUserId { get; set; }
        public Guid FollowingUserId { get; set; }
    }
}
