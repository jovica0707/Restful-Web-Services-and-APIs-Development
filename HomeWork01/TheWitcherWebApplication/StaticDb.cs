using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using TheWitcherWebApplication.Models;

namespace TheWitcherWebApplication
{
    public static class StaticDb
    {
        public static int IdUser = 3;
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FullName = "Geralt of Rivia",
                Quote = "F***",
            },
            new User
            {
                Id = 2,
                FullName = "Yennefer",
                Quote = "i'm gorgeous",
            },
            new User
            {
                Id = 3,
                FullName = "Jaskier",
                Quote = "toss a coin to your witcher",

            }
        };

        public static List<string> FullUsers = new List<string>
        {
            "Geralt of Rivia F***",
            "Yennefer i'm gorgeous",
            "Jaskier toss a coin to your witcher"

        };
    }
}
