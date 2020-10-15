using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.DataAccess.Implementations;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Mappers;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Enums;
using SEDC.NotesApp.Shared.Exceptions;
using SEDC.NotesApp.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            
            _userRepository = userRepository;
        }
        public void AddUser(UserModel noteModel)
        {
            UserValidation.ValidateNoteModel(noteModel);

            User user = userModel.ToUser();
           
            _userRepository.Add(user);
        }

        public void DeleteUser(int id)
        {
            User userDb = _userRepository.GetById(id);
            if (userDb == null)
            {
                throw new NotFoundException(id);
            }
            _userRepository.Delete(userDb);
        }

        public List<UserModel> GetAllUsers()
        {
            List<User> userDb = _userRepository.GetAll();

            return users.Select(x => x.ToUserModel())
                .ToList();
        }

        public UserModel GetUserById(int id)
        {
            User userDb = _userRepository.GetById(id);
            if (userDb == null)
            {
               
                throw new NotFoundException($"Note with id {id} was not found!");
               
            }

            return userDb.ToUserModel();
        }

        public void UpdateUser(UserModel noteModel)
        {
            User user = _userRepository.GetById(userModel.Id);
            if (user == null)
            {
                throw new NotFoundException(userModel.Id);
            }
            UserValidation.ValidateUserModel(userModel);

            userDb.FirstName = userModel.FirstName;
            userDb.LastName = userModel.LastName;
            userDb.Username = userModel.Username;
           
            _userRepository.Update(userDb);
        }
    }
}
