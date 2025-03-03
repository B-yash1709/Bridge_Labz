using System;
using ModelLayer.DTO;
using RepositoryLayer.Interface;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Context;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Service
{
    public class RegisterHelloRL : IRegisterHelloRL
    {
        private readonly ILogger<RegisterHelloRL> _logger;
        private readonly HelloAppContext _DbContext;

        public RegisterHelloRL(ILogger<RegisterHelloRL> logger, HelloAppContext DbContext) 
        {
            _logger = logger;
            _DbContext = DbContext;
        }

        public string GetHello(string name)
        {
            try
            {
                return name + " Hello from Repository layer ";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetHello method");
                throw;
            }
        }

        public UserEntity GetUsernamePassword(LoginDTO loginDTO)
        {
            try
            {
                var existingUser = _DbContext.Users.FirstOrDefault<UserEntity>(e =>
                        e.Email == loginDTO.Email && e.Password == loginDTO.Password

                        );

                return existingUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching username and password");
                throw;
            }
        }

        public UserEntity Registration(RegisterDTO registerDTO)
        {
            var existingUser = _DbContext.Users.FirstOrDefault<UserEntity>(e =>
                        e.Email== registerDTO.Email
                        );

            if(existingUser == null)
            {
                var newUser = new UserEntity
                {                    
                    FirstName = registerDTO.FirstName,
                    LastName = registerDTO.LastName,
                    Email = registerDTO.Email,
                    Password = registerDTO.Password
                };

                _DbContext.Users.Add(newUser);
                _DbContext.SaveChanges();
                return newUser;
            }
            

            return existingUser;
        }
    }
}
