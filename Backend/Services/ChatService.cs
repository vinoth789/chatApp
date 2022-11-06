using System.Collections.Generic;
using System.Linq;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Backend.Helpers;
using Backend.Models;
using System;
using System.Data;


namespace Backend.Services
{
    public interface IChatService
    {
        IEnumerable<ChatUserModel> GetAllChats();
        Chat GetChatById(int id);
        Chat CreateChat(Chat chat);
    }


    public class ChatService : IChatService
    {
        private DataContext _context;

        public ChatService(DataContext context)
        {
            _context = context;
        }

        public Chat CreateChat(Chat chat)
        {
            _context.Set<Chat>().Add(chat);
            _context.SaveChanges();
            return chat;
        }

        public IEnumerable<ChatUserModel> GetAllChats()
        {
            return from chat in _context.ChatEntries
                   from user in _context.UserEntries
                   where chat.UserId == user.Id
                   select new ChatUserModel
                   {
                       Id = chat.Id,
                       UserId = chat.UserId,
                       Message = chat.Message,
                       CreatedTimestamp = chat.CreatedTimestamp,
                       Username = user.Username
                   };
        }

        public Chat GetChatById(int Id)
        {
            return _context.ChatEntries.Find(Id);
        }

    }
}