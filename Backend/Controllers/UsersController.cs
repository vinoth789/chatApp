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
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly DataContext _context;
        private IMapper _mapper;
        private IUserService _userService;

        public UsersController(DataContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = _userService.GetAllUsers();
            var userModel = _mapper.Map<IList<UserModel>>(users);
            return Ok(userModel);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel newUser)
        {
            // map model to entity
            var user = _mapper.Map<User>(newUser);
            try
            {
                // create user
                _userService.CreateUser(user);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var user = _userService.GetUserById(Id);
            var userModel = _mapper.Map<UserModel>(user);
            return Ok(user);
        }
    }
}
