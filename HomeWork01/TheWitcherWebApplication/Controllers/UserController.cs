using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TheWitcherWebApplication.Models;

namespace TheWitcherWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.Users);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "what is your favorite scary movie ?");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetAllFullUsers(int id)
        {
            try
            {
                if (id > StaticDb.Users.Count())
                {
                    return StatusCode(StatusCodes.Status404NotFound, "nobody home bob");
                }
                User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "battery aziz");
                }
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hmm");
            }
        }
        [HttpGet("fullNames")]

        public ActionResult<List<string>> GetAllFullUsers()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.FullUsers);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "is now safe to turn off computer");
            }
        }

        [HttpPost]
        public IActionResult AddUser()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Request.Body))
                {
                    var user = JsonConvert.DeserializeObject<User>(sr.ReadToEnd());
                    if (user is User)
                    {
                        user.Id = StaticDb.IdUser++;
                        StaticDb.Users.Add(user);
                        return StatusCode(StatusCodes.Status201Created, "Get your s*** and get out");
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, "Gust get out Dude");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Haha.. With... What ?");
            }
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Request.Body))
                {
                    bool isNum = int.TryParse(sr.ReadToEnd(), out int id);
                    if (!isNum)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "wrong turn bob!");
                    }
                    User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
                    if (user == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "sorry who are you again ?");
                    }
                    StaticDb.Users.Remove(user);
                    return StatusCode(StatusCodes.Status204NoContent, "congratulation you are deleted");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " come on !! leave me alone go to sleep");
            }
        }
    }    
}
