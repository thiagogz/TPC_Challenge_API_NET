using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Repository.Interface;
using TPC_Challenge_API_NET.Repository;


namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var uid = await _authRepository.RegisterUserAsync(request);
                return Ok(new { Uid = uid });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO request)
        {
            var token = await _authRepository.LoginUserAsync(request);
            return Ok(new { Token = token });
        }
    }
}
