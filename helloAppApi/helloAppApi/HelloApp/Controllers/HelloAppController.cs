using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using ModelLayer.DTO;
using Microsoft.Extensions.Logging;

namespace HelloApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloAppController : ControllerBase
    {
        private readonly IRegisterHelloBL _registerHelloBL;
        private readonly ILogger<HelloAppController> _logger;

        public HelloAppController(ILogger<HelloAppController> logger, IRegisterHelloBL registerHelloBL)
        {
            _registerHelloBL = registerHelloBL;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Processing GET request in HelloAppController.");
                string result = _registerHelloBL.Registration("Value from controller");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GET request.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser(LoginDTO loginDTO)
        {
            var response = new ResponseModel<string>();

            try
            {
                _logger.LogInformation("Login attempt for user: {Username}", loginDTO.Email);

                bool result = _registerHelloBL.LoginUser(loginDTO);

                if (result)
                {
                    response.Success = true;
                    response.Message = "Login Successful";
                    response.Data = loginDTO.Email;
                    _logger.LogInformation("User {Username} logged in successfully", loginDTO.Email);
                    return Ok(response);
                }

                response.Success = false;
                response.Message = "Login failed";
                response.Data = null;
                _logger.LogWarning("Login failed for user: {Username}", loginDTO.Email);
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while processing login.";
                response.Data = ex.Message;

                _logger.LogError(ex, "Exception during login for user: {Username}", loginDTO.Email);
                return StatusCode(500, response);
            }
        }

        [HttpPost("register")]
        public IActionResult RegistrationUser(RegisterDTO registerDTO)
        {
            try
            {
                var result = _registerHelloBL.RegisterBL(registerDTO);

                var response = new ResponseModel<RegistrationResponse>
                {
                    Success = true,
                    Message = "Registration successful",
                    Data = result
                };

                return Created("User created", response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel<string>
                {
                    Success = false,
                    Message = "An error occurred during registration.",
                    Data = ex.Message
                };

                _logger.LogError(ex, "Error during user registration");
                return StatusCode(500, response);
            }
        }
    }
}
