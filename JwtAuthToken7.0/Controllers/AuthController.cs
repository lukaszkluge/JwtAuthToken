using JwtAuthToken7._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


namespace JwtAuthToken7._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Create a user variable to be used within the controller

        public static User user = new User();
        private readonly IConfiguration _configuration;

        // Controller constructor that takes configuration as a parameter
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]

        public ActionResult<User> Register(UserRequest request)
        {
            // Hash the user's password before storing it in the database
            
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Set the username and password hash in the user object

            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            
            return Ok(user);
        }

        [HttpPost("login")]

        public ActionResult<User> Login(UserRequest request)
        {
            // Check if a user with the given username exists

            if (user.Username != request.Username)
            {
                return BadRequest("User not found.");
            }

            // Verify the password provided by the user

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            // Create a JWT token for user authentication

            string token = CreateToken(user);

            return Ok(token);
        }

        // Function to generate a JWT token
        private string CreateToken(User user)
        {
            // Create a list of claims, typically containing user data

            List<Claim> claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Create a key used for signing the token

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            // Create the credentials needed for token signing

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Create a JWT token with specified claims and signing data

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            // Create and return a JWT string

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

    }
}
