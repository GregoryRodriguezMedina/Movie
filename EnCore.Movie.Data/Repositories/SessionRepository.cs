﻿using EnCore.Core;
using EnCore.Movie.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;

namespace EnCore.Movie.Data
{
    public partial interface ISessionRepository : EnCore.Core.IEfRepositoryBase<int, Session>
    {
        bool Exists(int userId);
        bool Exists(string machine);
    }

    public class SessionRepository : EnCore.Core.EfRepositoryBase<int, Session>, ISessionRepository
    {
        public SessionRepository(DbContext context) : base(context)
        {
        }

        public bool Exists(int userId)
        {
            return this.Entity
                .Any(a => a.UserId == userId && a.CreatedOn == DateTime.Now.Date);
        }

        public bool Exists(string machine)
        {
            return this.Entity
                .Any(a => a.Machine == machine && a.CreatedOn == DateTime.Now.Date);
        }
    }
}