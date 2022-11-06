
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Backend.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string Message { get; set; }

    }
}