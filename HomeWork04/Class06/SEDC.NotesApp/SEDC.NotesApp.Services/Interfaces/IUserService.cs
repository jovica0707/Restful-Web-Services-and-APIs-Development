using System;
using System.Collections.Generic;
using System.Text;
using SEDC.NotesApp.Models;

namespace SEDC.NotesApp.Services.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        void AddUser(UserModel noteModel);
        void UpdateUser(UserModel noteModel);
        void DeleteUser(int id);
    }
}
