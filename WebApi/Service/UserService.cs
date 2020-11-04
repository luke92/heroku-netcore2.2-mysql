namespace WebApiBancoNacion.Service
{
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApiBancoNacion.Models;

    public class UserService : IUserService
    {
        public UserService(IConfiguration configuration)
        {
            Users = new List<User>
            {
                new User { Id = 1, UserName = configuration["userid"], Password = configuration["password"] }
            };
        }
        private List<User> Users { get; set; }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => Users.SingleOrDefault(x => x.UserName == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }
    }
}