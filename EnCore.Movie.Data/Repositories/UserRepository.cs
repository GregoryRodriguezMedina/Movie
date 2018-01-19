using EnCore.Core;
using EnCore.Movie.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;

namespace EnCore.Movie.Data
{
    public partial interface IUserRepository : EnCore.Core.IEfRepositoryBase<int, User>
    {
        User Login(string name, string password);         
    }

    public class UserRepository : EnCore.Core.EfRepositoryBase<int, User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
       
        public User Login(string name, string password)
        {
           return this.Entity
                .Where(a => a.UserName == name && a.PassWord == password)
                .FirstOrDefault();
        }
    }
}