using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SEDC.NotesApp.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Username = userModel.UserName
            };
            
        }
        public static UserModel ToUserModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Username,
                Notes = user.Notes.Select(x => x.ToNoteModel()).ToList()
            };
        }
    }
}
