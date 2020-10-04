using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book ()
            {
                
                Author = "Frank Herbert",
                Title = "Dune",
                Genre = "Science Fiction",
                
            },
            new Book ()
            {
               
                Author = "Philip K. Dick",
                Title = "The Man in the High Castle",
                Genre = "Science Fiction",
                
            },
            new Book()
            {
                
                Author = "Robert Ludlum",
                Title = "The Bourne Identity",
                Genre = "Thriller",
                

            }
        };
    }
}
