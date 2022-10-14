
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using ToDoLiist_CORE.Manager.Interface;
using ToDoList.Models;
using ToDoList.ModelView;

namespace ToDoList.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : ApiBaseController
    {
        private IUserManager _userManager;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserManager userManager,
                              ILogger<UserController> logger)
        {
            _logger = logger;
            _userManager = userManager;
        }
       

        // GET: api/<UserController>
        [HttpGet]
        [Route("api/user")]
        public IActionResult Get()
        {
            var res = _userManager.Get();
            return Ok(res);
        }

      

      
        [Route("api/user/reg")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserRegistrationModel userReg)
        {
            var user = _userManager.SignUp(userReg);
            return Ok(user);
        }

        // POST api/<UserController>
        [Route("api/user/login")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModelView userReg)
        {
            var res = _userManager.Login(userReg);
            return Ok(res);
        }


        [Route("api/user/fileretrive/profilepic")]
        [HttpGet]
        public IActionResult Retrive(string filename)
        {
            var folderPath = Directory.GetCurrentDirectory();
            folderPath = $@"{folderPath}\{filename}";
            var byteArray = System.IO.File.ReadAllBytes(folderPath);
            return File(byteArray, "image/jpeg", filename);
        }

        // PUT api/<UserController>/5

            [Route("api/user/Update")]
            [HttpPut]
            [Authorize]
            public IActionResult UpdateUser(UpdateUser request)
            {
                var user = _userManager.UpdateUser(LoggedInUser, request);
                return Ok(user);
            }


            [HttpDelete]
            [Route("api/user/Delete/{id}")]
            public IActionResult Delete(int id)
            {
                _userManager.DeleteUser(LoggedInUser, id);
                return Ok();
            }

            #region private 

            private static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return hashedPassword;
        }

        private static bool VerifyHashPassword(string password, string HashedPasword)
        {
            return BCrypt.Net.BCrypt.Verify(password, HashedPasword);
        }

        private string GenerateJWTToken(User user)
        {
            var jwtKey = "#test.key*&^vanthis%$^&*()$%^@#$@!@#%$#^%&*%^*";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Id", user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("DateOfJoining", user.CreatedDate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var issuer = "test.com";

            var token = new JwtSecurityToken(
                        issuer,
                        issuer,
                        claims,
                        expires: DateTime.Now.AddDays(20),
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion private  
    }
}
