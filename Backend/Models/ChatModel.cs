using Backend.Entities;
using System;

namespace Backend.Models
{
    public class ChatModel
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string Message { get; set; }

    }
}
