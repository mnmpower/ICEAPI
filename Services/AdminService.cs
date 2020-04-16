using ICE_API.Helpers;
using ICE_API.models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ICE_API.Services
{
    public class AdminService : IAdminService
    {
        private AppSettings _appSettings;
        private DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AdminService(IOptions<AppSettings> appSettings, DataContext dataContext, IConfiguration configuration)
        {
            _appSettings = appSettings.Value;
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public Admin Authenticate(string email, string password)
        {
            var admin = _dataContext.Admins.SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if Admin not found
            if (admin == null)
                return null;

            var appSettingsSection = _configuration.GetSection("AppSettings");

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();


            // authentication successful so generate jwttoken
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("AdminID", admin.AdminID.ToString()),
                    new Claim("Email", admin.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            admin.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            admin.Password = null;
            return admin;
        }
    }
}
