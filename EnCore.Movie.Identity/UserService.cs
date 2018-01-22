using EnCore.Core;
using EnCore.Movie.Core;
using EnCore.Movie.Data;
using System;
using System.Security.Principal;
using System.Threading;

namespace EnCore.Movie.Identity
{
    public partial class UserService
    {
        private readonly IUserRepository userRepository;
        private readonly ISessionRepository sessionRepository;

        public UserService(IUserRepository userRepository, ISessionRepository sessionRepository)
        {
            this.userRepository = userRepository;
            this.sessionRepository = sessionRepository;
        }

        public bool ExistsSession()
        {
            IPrincipal threadPrincipal = Thread.CurrentPrincipal;

            if (threadPrincipal == null)
            {
                if (this.sessionRepository.Exists(GetCumputeName()))
                    return true;
                
                return false;
            }

            if (!threadPrincipal.Identity.IsAuthenticated)
                return false;

            int userId = int.Parse(threadPrincipal.Identity.Name);

            return this.sessionRepository.Exists(userId);
        }

        public object Login(LoginRequest login)
        {
            return this.Login(login.User, login.Password);
        }

        private string GetCumputeName() {
          //  Request.ServerVariables["REMOTE_USER"]

          //  string PCName = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName;


            return Environment.GetEnvironmentVariable("CUMPUTERNAME") ?? Environment.GetEnvironmentVariable("HOSTNAME");
        }

        public LoginResponse Login(string user, string password)
        {
            var query = this.userRepository.Login(user, password);
            if (query == null)
                throw new BusinessException("El usuario o password son invalidos.");

            
            this.sessionRepository.Insert(new Session
            {
                CreatedOn = DateTime.Now,
                UserId = query.UserId,
                Token = Guid.NewGuid(),
                Machine = GetCumputeName()
            });

            Thread.CurrentPrincipal =
                new GenericPrincipal(new GenericIdentity(query.UserId.ToString()), new string[] { "admin" });

            this.userRepository.SaveChanges();

            return new LoginResponse
            {
                Display = query.DisplayName,
                Key = query.UserId,
                Name = query.UserName
            };
        }
    }
}