using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tazeez.Common.Extensions;
using ToDoLiist_CORE.Manager.Interface;
using ToDoList.Helper;
using ToDoList.Models;
using ToDoList.ModelView;

namespace ToDoLiist_CORE.Manager
{
    public class UserManager : IUserManager
    {
        #region public

        private IMapper _mapper;
        private todolistContext _dbcontext;

        public UserManager(todolistContext dbcontext, IMapper mapper)
        {
            dbcontext = _dbcontext;
            _mapper = mapper;
        }


        public LoginUserResponse Login(LoginModelView userReg)
        {
            var user = _dbcontext.Users
                                   .FirstOrDefault(a => a.Email.ToLower().Equals(userReg.Email.ToLower()));

            if (user == null || !VerifyHashPassword(userReg.Password, user.Password))
            {
                throw new ServiceValidationException(300, "Invalid user name or password received");
            }

            var res = _mapper.Map<LoginUserResponse>(user);
            res.Token = $"Bearer {GenerateJWTToken(user)}";
            return res;
        }


        public LoginUserResponse SignUp(UserRegistrationModel userReg)
        {
            if (_dbcontext.Users.Any(a => a.Email.ToLower().Equals(userReg.Email.ToLower())))
            {
                throw new ServiceValidationException("User already exist");
            }

            var hashedPassword = HashPassword(userReg.Password);

            var user = _dbcontext.Users.Add(new User
            {
                FirstName = userReg.FirstName,
                LastName = userReg.LastName,
                Email = userReg.Email.ToLower(),
                Password = hashedPassword,
                ConfPassword = hashedPassword,
                Image = string.Empty
            }).Entity;

            _dbcontext.SaveChanges();

            var res = _mapper.Map<LoginUserResponse>(user);
            res.Token = $"Bearer {GenerateJWTToken(user)}";

            return res;

        }

        public UserView UpdateProfile(UserView currentUser, UpdateUser UpUser)
        {
            var user = _dbcontext.Users
                                    .FirstOrDefault(a => a.Id == currentUser.Id)
                                    ?? throw new ServiceValidationException("User not found");

            var url = "";

            if (!string.IsNullOrWhiteSpace(UpUser.ImageString))
            {
                url = Helper.SaveImage(UpUser.ImageString, "profileimages");
            }

            user.FirstName = UpUser.FirstName;
            user.LastName = UpUser.LastName;

            if (!string.IsNullOrWhiteSpace(url))
            {
                var baseURL = "https://localhost:44309/";
                user.Image = @$"{baseURL}/api/v1/user/fileretrive/profilepic?filename={url}";
            }

            _dbcontext.SaveChanges();
            return _mapper.Map<UserView>(user);
        }


        public void DeleteUser(UserView currentUser, int id)
        {
            if (currentUser.Id == id)
            {
                throw new ServiceValidationException("You have no access to delete your self");
            }

            var user = _dbcontext.Users
                          .FirstOrDefault(a => a.Id == id)
                          ?? throw new ServiceValidationException("User not found");
            
            user.Archived = true;
            _dbcontext.SaveChanges();
        }


        public List<UserView> Get()
        {
            return _mapper.Map<List<UserView>>(_dbcontext.Users.ToList());
        }


        #endregion public




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

        public UserView UpdateUser(UserView currentUser, UpdateUser request)
        {
            throw new NotImplementedException();
        }




        #endregion private



    }
}
