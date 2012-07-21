using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.User.Authentication.UserList.Data.Abstract;
using ThreeBytes.User.Authentication.UserList.Entities;
using ThreeBytes.User.Authentication.UserList.Entities.Enums;
using ThreeBytes.User.Authentication.UserList.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserList.Service.Concrete
{
    public class AuthenticationUserListUserService : KeyedGenericService<AuthenticationUserListUser>, IAuthenticationUserListUserService
    {
        protected new readonly IAuthenticationUserListUserRepository Repository;

        public AuthenticationUserListUserService(IAuthenticationUserListUserRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IList<AuthenticationUserListUser> GetAll(string applicationName)
        {
            Func<IList<AuthenticationUserListUser>> getData = () => Repository.GetAll(applicationName);

            if (CacheEnabled)
                return Cache.FetchOrdered(getData, applicationName);
                
            return getData();
        }

        public IPagedResult<AuthenticationUserListUser> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, AuthenticationUserListUserOrderBy orderBy = AuthenticationUserListUserOrderBy.Username, SortBy sortBy = SortBy.Asc, int page = 1)
        {
            Func<IPagedResult<AuthenticationUserListUser>> getData = () => Repository.GetAllPaged(take, originalRequestDateTime, applicationName, orderBy, sortBy, page);

            if (CacheEnabled)
                return Cache.Fetch(page, originalRequestDateTime, orderBy.ToString(), sortBy.ToString(), getData);
                
            return getData();
        }

        public IMostRecentResult<AuthenticationUserListUser> GetLatestSince(DateTime datetime, string applicationName)
        {
            Func<IMostRecentResult<AuthenticationUserListUser>> getData = () => Repository.GetLatestSince(datetime, applicationName);

            if (CacheEnabled)
                return Cache.Fetch(datetime, getData);

            return getData();
        }

        public IList<AuthenticationUserListUser> GetMostRecent(int take, string applicationName)
        {
            return Repository.GetMostRecent(take, applicationName);
        }

        public int Count(string applicationName)
        {
            return Repository.Count(applicationName);
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Repository.UniqueUsername(username, applicationName);
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Repository.UniqueEmail(email, applicationName);
        }
    }
}
