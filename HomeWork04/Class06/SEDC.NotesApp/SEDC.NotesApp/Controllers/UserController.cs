using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Enums;
using SEDC.NotesApp.Shared.Exceptions;

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
        public ActionResult<List<UserModel>> Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _userService.GetAllUsers());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " WRONG BAY!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _userService.GetUserById(id));
            }
            catch (Status400BadRequest ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "WRONG BAY!");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserModel userModel)
        {
            try
            {
                _userService.AddUser(userModel);
                return StatusCode(StatusCodes.Status201Created, "Hallo New User!");
            }
            catch (Status400BadRequest ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (NoteException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "WRONG BAY!");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UserModel userModel)
        {
            try
            {
                _userService.UpdateUser(userModel);
                return StatusCode(StatusCodes.Status204NoContent, "Now I have a machine gun. ... Ho ho ho!");
            }
            catch (Status400BadRequest ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (NoteException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "WRONG BAY!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return StatusCode(StatusCodes.Status204NoContent, "Yippee Ki Yay !");
            }
            catch (Status400BadRequest ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "WRONG BAY!");
            }
        }
    }
}
