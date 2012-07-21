using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Role.List.Data.Abstract;
using ThreeBytes.User.Role.List.Data.Abstract.Infrastructure;
using ThreeBytes.User.Role.List.Entities;
using ThreeBytes.User.Role.List.Entities.Enums;

namespace ThreeBytes.User.Role.List.Data.Concrete
{
    public class RoleListRoleRepository: KeyedGenericRepository<RoleListRole>, IRoleListRoleRepository
    {
        public RoleListRoleRepository(IRoleListRoleDatabaseFactory databaseFactory, IRoleListRoleUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public virtual IList<RoleListRole> GetAll(string applicationName)
        {
            var entity = Session.QueryOver<RoleListRole>()
                .Where(x => x.ApplicationName == applicationName)
                .List();

            return entity;
        }

        public virtual IPagedResult<RoleListRole> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, RoleListRoleOrderBy orderBy = RoleListRoleOrderBy.Name, SortBy sortBy = SortBy.Asc, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

           var query = Session.QueryOver<RoleListRole>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName);

            switch (orderBy)
            {
                case RoleListRoleOrderBy.Name:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.Name).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.Name).Desc;
                            break;
                    }
                    break;
                case RoleListRoleOrderBy.ApplicationName:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.ApplicationName).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.ApplicationName).Desc;
                            break;
                    }
                    break;
                case RoleListRoleOrderBy.CreationDateTime:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.CreationDateTime).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.CreationDateTime).Desc;
                            break;
                    }
                    break;
                case RoleListRoleOrderBy.LastModifiedDateTime:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.LastModifiedDateTime).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.LastModifiedDateTime).Desc;
                            break;
                    }
                    break;
            }

            IList<RoleListRole> roles = query.Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<RoleListRole>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();

            return new PagedResult<RoleListRole>(roles, originalRequest, recordsInThisQuery, page, take);
        }

        public virtual IMostRecentResult<RoleListRole> GetLatestSince(DateTime datetime, string applicationName)
        {
            DateTime now = DateTime.Now;

            IList<RoleListRole> newestTEntities = Session.QueryOver<RoleListRole>()
                .Where(x => x.CreationDateTime > datetime)
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .List();

            return new MostRecentResult<RoleListRole>(newestTEntities, datetime, now);
        }

        public IList<RoleListRole> GetMostRecent(int take, string applicationName)
        {
            IList<RoleListRole> result = Session.QueryOver<RoleListRole>()
                .Where(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }

        public int Count(string applicationName)
        {
            int result = Session.QueryOver<RoleListRole>()
                .Where(x => x.ApplicationName == applicationName)
                .RowCount();

            return result;
        }

        public bool Exists(string name, string applicationName)
        {
            return Session.QueryOver<RoleListRole>()
                       .Where(x => x.Name == name)
                       .And(x => x.ApplicationName == applicationName)
                       .RowCount() != 0;
        }
    }
}
