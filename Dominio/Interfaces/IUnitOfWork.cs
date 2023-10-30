using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IRolRepository Roles {get;}
        IUserRepository Users {get;}
        Task<int> SaveAsync();
    }
}