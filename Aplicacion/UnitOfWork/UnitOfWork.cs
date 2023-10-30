using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Proyecto4CapasContext _context;
        public UnitOfWork(Proyecto4CapasContext context)
        {
            _context = context;
        }

        private RolRepository _rol;
        public IRolRepository Roles
        {
            get
            {
                if (_rol == null)
                {
                    _rol = new RolRepository(_context);
                }
                return _rol;
            }
        }

        private UserRepository _user;
        public IUserRepository Users
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}