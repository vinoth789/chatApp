using Backend.Entities;
using System;

namespace Backend.Models
{
    public class ChatUserModel
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string Message { get; set; }

    }
}
