using backend.DataAccess.Contracts;
using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Repositories
{
    public class UsersRepository : RepositoryBase<UsersEntity>, IUsersRepository
    {
        public UsersRepository( RepositoryContext repositoryContext) : base (repositoryContext)
        {

        }
    }
}
