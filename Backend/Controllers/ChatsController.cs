using Backend.Models;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Helpers;
using Backend.Services;
using System;

namespace Backend.Controllers
{
    [Route("api/chats")]
    public class ChatsController : Controller
    {
        private readonly DataContext _context;
        private IMapper _mapper;
        private IChatService _chatService;

        public ChatsController(DataContext context, IMapper mapper, IChatService chatService)
        {
            _context = context;
            _mapper = mapper;
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chats =  _chatService.GetAllChats();
            return Ok(chats);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ChatModel newChat)
        {
            // map model to entity
            var chat = _mapper.Map<Chat>(newChat);
            try
            {
                // create chat
                 _chatService.CreateChat(chat);
                 return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
