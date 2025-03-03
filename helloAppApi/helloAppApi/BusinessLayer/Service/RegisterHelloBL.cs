using System;
using BusinessLayer.Interface;
using ModelLayer.DTO;
using RepositoryLayer.Interface;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Entity;

namespace BusinessLayer.Service
{
    public class RegisterHelloBL : IRegisterHelloBL
    {
        readonly IRegisterHelloRL _registerHelloRL;
        private readonly ILogger<RegisterHelloBL> _logger;

        public RegisterHelloBL(IRegisterHelloRL registerHelloRL, ILogger<RegisterHelloBL> logger)
        {
            _registerHelloRL = registerHelloRL;
            _logger = logger;
        }

        public string Registration(string name)
        {
            try
            {
                return " Data from Business Layer " + _registerHelloRL.GetHello(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in registration for name: {Name}", name);
                throw;
            }
        }

        public bool LoginUser(LoginDTO loginDTO)
        {
            try
            {
                string frontendUsername = loginDTO.Email;
                string frontendPassword = loginDTO.Password;

                UserEntity result = _registerHelloRL.GetUsernamePassword(loginDTO);

                bool res = CheckUsernamePassword(frontendUsername, frontendPassword, result);

                if (res)
                    _logger.LogInformation("Login successful for user: {Username}", frontendUsername);
                else
                    _logger.LogWarning("Login failed for user: {Username}", frontendUsername);

                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user: {Username}", loginDTO.Email);
                throw;
            }
        }

        private bool CheckUsernamePassword(string frontendUsername, string frontendPassword, UserEntity result)
        {
            try
            {

                return result != null && frontendUsername.Equals(result.Email) && frontendPassword.Equals(result.Password);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CheckUsernamePassword for user: {Username}", frontendUsername);
                throw;
            }
        }

        public RegistrationResponse RegisterBL(RegisterDTO registerDTO)
        {
            try
            {
                var result = _registerHelloRL.Registration(registerDTO);
                var response = new RegistrationResponse
                {
                    UserId = result.UserId,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in user registration");
                throw;
            }
        }
    }
}
