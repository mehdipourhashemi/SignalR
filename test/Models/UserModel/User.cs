using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models.MessageModel;

namespace test.Models.UserModel
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ConnectionId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogInDate { get; set; }
        public bool IsOnline { get; set; } = false;
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<Message> SendMessages { get; set; }
        public virtual ICollection<Contact> FollowingUsers { get; set; }
        public virtual ICollection<Contact> FollowerUsers { get; set; }
    }
}
