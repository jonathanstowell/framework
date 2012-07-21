using System.Collections.Generic;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Data.Concrete
{
    public class AuthenticationUserManagementRoleRepository : KeyedGenericRepository<AuthenticationUserManagementRole>, IAuthenticationUserManagementRoleRepository
    {
        public AuthenticationUserManagementRoleRepository(IAuthenticationUserManagementUserDatabaseFactory databaseFactory, IAuthenticationUserManagementUserUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public IList<AuthenticationUserManagementRole> GetAll(string applicationName)
        {
            var entity = Session.QueryOver<AuthenticationUserManagementRole>()
               .Where(x => x.ApplicationName == applicationName)
               .List();

            return entity;
        }

        public AuthenticationUserManagementRole GetByName(string name)
        {
            return Session.QueryOver<AuthenticationUserManagementRole>().Where(x => x.Name == name).SingleOrDefault();
        }

        public bool Exists(string name, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserManagementRole>()
                       .Where(x => x.Name == name)
                       .And(x => x.ApplicationName == applicationName)
                       .RowCount() != 0;
        }
    }
}
