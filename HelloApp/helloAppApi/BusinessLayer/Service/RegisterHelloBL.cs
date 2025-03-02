using System;
using BusinessLayer.Interface;
using ModelLayer.DTO;
using RepositoryLayer.Interface;
using Microsoft.Extensions.Logging;

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

        public string registration(string name)
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

        public bool loginuser(LoginDTO loginDTO)
        {
            try
            {
                string frontendUsername = loginDTO.username;
                string frontendPassword = loginDTO.password;

                LoginDTO result = _registerHelloRL.GetUsernamePassword(loginDTO);

                bool res = CheckUsernamePassword(frontendUsername, frontendPassword, result);

                if (res)
                    _logger.LogInformation("Login successful for user: {Username}", frontendUsername);
                else
                    _logger.LogWarning("Login failed for user: {Username}", frontendUsername);

                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user: {Username}", loginDTO.username);
                throw;
            }
        }

        private bool CheckUsernamePassword(string frontendUsername, string frontendPassword, LoginDTO result)
        {
            try
            {
                return result != null && frontendUsername.Equals(result.username) && frontendPassword.Equals(result.password);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CheckUsernamePassword for user: {Username}", frontendUsername);
                throw;
            }
        }
    }
}