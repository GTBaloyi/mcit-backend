using backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Contracts
{
    interface IUserStatusRepository : IRepositoryBase<UserStatusEntity>
    {
    }
}
