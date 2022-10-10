using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using test.ViewModels;

namespace test.Utilities
{
    public class EncryptionUtility
    {
        string tokenKey = "RTES TY 1565 WE TEST AKZ AERIFY ERT OOKENS, REPLACE AB POIN YOUN OWN SECRET, IT HTR PO RET STRING";
        public EncryptionUtility()
        {
            
        }
        public string GetSHA256(string password, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(password + salt);
            var hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            return hash;
        }
        public string GetNewSalt()
        {
            return Guid.NewGuid().ToString();
        }
        public string GetNewRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
        public string GetNewToken(Guid userId, string FirstName, string LastName, string UserName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", userId.ToString()),
                    new Claim("FirstName", FirstName),
                    new Claim("LastName", LastName),
                    new Claim("UserName", UserName),
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public UserDto UserInfo(HttpContext context)
        {
            var cookie = context.Request.Cookies["ChatToken"];
            if(cookie != null && ValidateToken(cookie))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(cookie);
                var tokenS = jsonToken as JwtSecurityToken;
                var userId = tokenS.Payload.Where(t => t.Key == "userId").FirstOrDefault().Value.ToString();
                var FirstName = tokenS.Payload.Where(t => t.Key == "FirstName").FirstOrDefault().Value.ToString();
                var LastName = tokenS.Payload.Where(t => t.Key == "LastName").FirstOrDefault().Value.ToString();
                var UserName = tokenS.Payload.Where(t => t.Key == "UserName").FirstOrDefault().Value.ToString();
                return new UserDto()
                {
                    Id = Guid.Parse(userId),
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = UserName,
                };
            }
            return null;
        }
        public UserDto UserInfo(HubCallerContext context)
        {
            var cookie = context.GetHttpContext().Request.Cookies["ChatToken"];
            if (cookie != null && ValidateToken(cookie))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(cookie);
                var tokenS = jsonToken as JwtSecurityToken;
                var userId = tokenS.Payload.Where(t => t.Key == "userId").FirstOrDefault().Value.ToString();
                var FirstName = tokenS.Payload.Where(t => t.Key == "FirstName").FirstOrDefault().Value.ToString();
                var LastName = tokenS.Payload.Where(t => t.Key == "LastName").FirstOrDefault().Value.ToString();
                var UserName = tokenS.Payload.Where(t => t.Key == "UserName").FirstOrDefault().Value.ToString();
                return new UserDto()
                {
                    Id = Guid.Parse(userId),
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = UserName,
                };
            }
            return null;
        }
        private static bool ValidateToken(string authToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = false, // Because there is no expiration in the generated token
                    ValidateAudience = false, // Because there is no audiance in the generated token
                    ValidateIssuer = false,   // Because there is no issuer in the generated token
                    ValidIssuer = "Sample",
                    ValidAudience = "Sample",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RTES TY 1565 WE TEST AKZ AERIFY ERT OOKENS, REPLACE AB POIN YOUN OWN SECRET, IT HTR PO RET STRING")) // The same key as the one that generate the token
                };

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
