using backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<AccessLevelEntity> AccessLayer { get; set; }
        public DbSet<BusinessRepresentativeEntity> BusinessRep { get; set; }
        public DbSet<UserStatusEntity> UserStatus { get; set; }

    }
}
