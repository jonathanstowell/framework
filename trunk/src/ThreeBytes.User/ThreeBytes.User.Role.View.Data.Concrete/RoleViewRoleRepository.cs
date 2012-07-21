using System;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Role.View.Data.Abstract;
using ThreeBytes.User.Role.View.Data.Abstract.Infrastructure;
using ThreeBytes.User.Role.View.Entities;

namespace ThreeBytes.User.Role.View.Data.Concrete
{
    public class RoleViewRoleRepository : HistoricKeyedGenericRepository<RoleViewRole>, IRoleViewRoleRepository
    {
        public RoleViewRoleRepository(IRoleViewRoleDatabaseFactory databaseFactory, IRoleViewRoleUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public bool Exists(Guid itemId, string name, string applicationName)
        {
            return Session.QueryOver<RoleViewRole>()
                       .Where(x => x.Name == name)
                       .And(x => x.ApplicationName == applicationName)
                       .And(x => x.ItemId != itemId)
                       .RowCount() != 0;
        }
    }
}
