using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            try
            {
                return StaticDb.Books;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "That all folks");
            }
        }

        [HttpGet("queryString")]
        public ActionResult<Book> GetOneBookByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "You bad boy");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Lassie is missing");
                }
                return StatusCode(StatusCodes.Status200OK, "Lassie is Home <3");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something is Burning");
            }
        }

        [HttpGet("queryParams")]
        public ActionResult<Book> GetOneBookByParams(int id, string author, string title, string genre, int year)
        {
            try
            {
                if (string.IsNullOrEmpty(author))
                {
                    Book book2 = StaticDb.Books.FirstOrDefault(x => x.Title == title);
                    if (book2 == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "Can't help you dude");
                    }
                    return StatusCode(StatusCodes.Status200OK, book2);
                }
                if (string.IsNullOrEmpty(title))
                {
                    Book book3 = StaticDb.Books.FirstOrDefault(x => x.Author == author);
                    if (book3 == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "Nobody Here But Us Chickens!");
                    }
                    return StatusCode(StatusCodes.Status200OK, book3);
                }
                if (string.IsNullOrEmpty(genre))
                {
                    Book book4 = StaticDb.Books.FirstOrDefault(x => x.Genre == genre);
                    if (book4 == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "Hello darkness my old friend");
                    }
                    return StatusCode(StatusCodes.Status200OK, book4);
                }
                Book book = StaticDb.Books.FirstOrDefault(x => x.Author == author && x.Title == title);
                if (book == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Nobody Home");
                }
                return StatusCode(StatusCodes.Status200OK, book);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "I thing something went wrong!");
            }
        }

        [HttpGet("contentType")]
        public IActionResult GetContentType([FromHeader(Name = "Content-Type")] string contentType)
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, contentType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Quit your job");
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, $"Book {book.Title} added to list!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Definitely Something is wrong");
            }
        }


        [HttpPost("postReturn")]
        public IActionResult ReturnBookTitles([FromBody] List<Book> books)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, books.Select(x => x.Title));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houston we have a problem");
            }
        }
    };
        
    
}
