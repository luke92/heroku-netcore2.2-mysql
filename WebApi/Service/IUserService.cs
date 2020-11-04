using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBancoNacion.Models;

namespace WebApiBancoNacion.Service
{    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}
