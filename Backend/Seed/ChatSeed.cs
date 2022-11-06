using Backend.Entities;
using System.Collections.Generic;

namespace Backend.Seed
{
    public class ChatSeed
    {
        public ChatSeed()
        {
            ChatEntries = new List<Chat>()
            {
                new Chat()
                {
                    Id = 1,
                    UserId = 2,
                    CreatedTimestamp = new System.DateTime(),
                    Message = "Hello dad!",
                },
                new Chat()
                {
                    Id = 2,
                    UserId = 1,
                    CreatedTimestamp = new System.DateTime(),
                    Message = "Hello dad*",
                }
            };
        }

        public List<Chat> ChatEntries { get; set; }
    }
}
