using EnCore.Movie.Core;
using EnCore.Movie.Data;
using System;
using System.Security.Principal;
using System.Threading;

namespace EnCore.Movie.Identity
{
    public partial class UserService
    {
        private readonly UserRepository userRepository;
        private readonly SessionRepository sessionRepository;

        public UserService(UserRepository userRepository, SessionRepository sessionRepository)
        {
            this.userRepository = userRepository;
            this.sessionRepository = sessionRepository;
        }

        public bool ExistsSession()
        {
            //IPrincipal threadPrincipal = Thread.CurrentPrincipal;

            //if (!threadPrincipal.Identity.IsAuthenticated)
            //    return false;

            //int userId = int.Parse(threadPrincipal.Identity.Name);

            //return this.sessionRepository.Exists(userId);

            return true;
        }

        public LoginResponse Login(string user, string password)
        {
            var query = this.userRepository.Login(user, password);
            if (query == null)
                throw new System.Security.SecurityException("El usuario o password son invalidos.");

            this.sessionRepository.Insert(new Session
            {
                CreatedOn = DateTime.Now,
                UserId = query.UserId
            });

            //Thread.CurrentPrincipal =
            //    new GenericPrincipal(new GenericIdentity(query.UserId.ToString()), new string[] { "admin" });



            return new LoginResponse
            {
                Display = query.DisplayName,
                Key = query.UserId,
                Name = query.UserName
            };
        }
    }
}