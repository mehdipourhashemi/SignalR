using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using test.Models.UserModel;

namespace test.Models.MessageModel
{
    public class MessageDto
    {
        
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public bool IsReceived { get; set; }
        public bool IsRead { get; set; }
        public Guid ReceiverUserId { get; set; }
        public virtual User ReceiverUser { get; set; }
        public Guid SenderUserId { get; set; }
        public virtual User SenderUser { get; set; }
        public bool IsReceivedMessage  { get; set; }
        public Guid UniqId { get; set; }
        public string ConnectionId { get; set; }
        public DateTime? FirstMessageTime { get; set; }

    }
}
