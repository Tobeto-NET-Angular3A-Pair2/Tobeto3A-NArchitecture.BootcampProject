using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Message : Entity<int>
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }

    public virtual User User { get; set; }

    public Message(int id, Guid senderId, Guid receiverId, string content, bool isRead)
    {
        Id = id;
        SenderId = senderId;
        ReceiverId = receiverId;
        Content = content;
        IsRead = isRead;
    }

    public Message() { }
}
