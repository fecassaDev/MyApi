using Microsoft.IdentityModel.Tokens;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Security
{
    public class SecurityService
    {
        const string CLIENT_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";

        public Login GetToken(Login user)
        {
            Validator<Login> validator = ValidationFactory.CreateValidator<Login>();
            ValidationResults validationResults = validator.Validate(user);

            if (!validationResults.IsValid)
            {
                throw new Exception("Um ou mais campos não foram preenchidos corretamente");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(CLIENT_KEY)), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.TokenAcess = tokenHandler.WriteToken(token);

            return user;
        }
    }
}
