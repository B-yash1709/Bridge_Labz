using System;
using ModelLayer.DTO;
using RepositoryLayer.Interface;
using Microsoft.Extensions.Logging;

namespace RepositoryLayer.Service
{
    public class RegisterHelloRL : IRegisterHelloRL
    {
        private readonly ILogger<RegisterHelloRL> _logger;
        private string databaseUsername = "root";
        private string databasePassword = "root";

        public RegisterHelloRL(ILogger<RegisterHelloRL> logger)
        {
            _logger = logger;
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

        public LoginDTO GetUsernamePassword(LoginDTO loginDTO)
        {
            try
            {
                loginDTO.username = databaseUsername;
                loginDTO.password = databasePassword;

                return loginDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching username and password");
                throw;
            }
        }
    }
}