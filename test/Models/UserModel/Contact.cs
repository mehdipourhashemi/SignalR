using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models.UserModel
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public virtual User FollowerUser { get; set; }
        public virtual User FollowingUser { get; set; }
        public Guid FollowerUserId { get; set; }
        public Guid FollowingUserId { get; set; }
        public DateTime Time { get; set; }
    }
}
