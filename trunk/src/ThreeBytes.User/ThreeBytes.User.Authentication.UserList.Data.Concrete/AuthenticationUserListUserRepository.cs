using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserList.Data.Abstract;
using ThreeBytes.User.Authentication.UserList.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserList.Entities;
using ThreeBytes.User.Authentication.UserList.Entities.Enums;

namespace ThreeBytes.User.Authentication.UserList.Data.Concrete
{
    public class AuthenticationUserListUserRepository: KeyedGenericRepository<AuthenticationUserListUser>, IAuthenticationUserListUserRepository
    {
        public AuthenticationUserListUserRepository(IAuthenticationUserListUserDatabaseFactory databaseFactory, IAuthenticationUserListUserUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public virtual IList<AuthenticationUserListUser> GetAll(string applicationName)
        {
            var entity = Session.QueryOver<AuthenticationUserListUser>()
                .Where(x => x.ApplicationName == applicationName)
                .List();
            
            return entity;
        }

        public virtual IPagedResult<AuthenticationUserListUser> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, AuthenticationUserListUserOrderBy orderBy = AuthenticationUserListUserOrderBy.Username, SortBy sortBy = SortBy.Asc, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            var query = Session.QueryOver<AuthenticationUserListUser>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName);

            switch (orderBy)
            {
                case AuthenticationUserListUserOrderBy.Username:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.Username).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.Username).Desc;
                            break;
                    }
                    break;
                case AuthenticationUserListUserOrderBy.ApplicationName:
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
                case AuthenticationUserListUserOrderBy.Email:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.Email).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.Email).Desc;
                            break;
                    }
                    break;
                case AuthenticationUserListUserOrderBy.IsVerified:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.IsVerified).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.IsVerified).Desc;
                            break;
                    }
                    break;
                case AuthenticationUserListUserOrderBy.IsLockedOut:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.IsLockedOut).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.IsLockedOut).Desc;
                            break;
                    }
                    break;
                case AuthenticationUserListUserOrderBy.CreationDateTime:
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
                case AuthenticationUserListUserOrderBy.LastModifiedDateTime:
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

            IList<AuthenticationUserListUser> users = query.Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<AuthenticationUserListUser>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();

            return new PagedResult<AuthenticationUserListUser>(users, originalRequest, recordsInThisQuery, page, take);
        }

        public virtual IMostRecentResult<AuthenticationUserListUser> GetLatestSince(DateTime datetime, string applicationName)
        {
            DateTime now = DateTime.Now;

            IList<AuthenticationUserListUser> newestTEntities = Session.QueryOver<AuthenticationUserListUser>()
                .Where(x => x.CreationDateTime > datetime)
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .List();

            return new MostRecentResult<AuthenticationUserListUser>(newestTEntities, datetime, now);
        }

        public IList<AuthenticationUserListUser> GetMostRecent(int take, string applicationName)
        {
            IList<AuthenticationUserListUser> result = Session.QueryOver<AuthenticationUserListUser>()
                .Where(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }

        public int Count(string applicationName)
        {
            int result = Session.QueryOver<AuthenticationUserListUser>()
                .Where(x => x.ApplicationName == applicationName)
                .RowCount();

            return result;
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserListUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserListUser>().Where(x => x.Email == email && x.ApplicationName == applicationName).RowCount() == 0;
        }
    }
}
