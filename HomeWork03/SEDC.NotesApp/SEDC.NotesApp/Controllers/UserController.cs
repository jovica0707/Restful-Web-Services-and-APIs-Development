﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Services.Interfaces;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _userService.AddUser(user);
            return StatusCode(StatusCodes.Status201Created, "Welcome to the world");
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return StatusCode(StatusCodes.Status204NoContent, "You got some mad skills");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return StatusCode(StatusCodes.Status204NoContent, "Hasta la vista, baby");
        }
    }
}
