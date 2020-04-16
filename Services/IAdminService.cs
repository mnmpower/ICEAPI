using ICE_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICE_API.Services
{
    public interface IAdminService
    {
        Admin Authenticate(string email, string password);
    }
}
