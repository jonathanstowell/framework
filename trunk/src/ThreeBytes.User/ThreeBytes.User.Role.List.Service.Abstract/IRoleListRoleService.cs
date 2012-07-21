﻿using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Role.List.Entities;
using ThreeBytes.User.Role.List.Entities.Enums;

namespace ThreeBytes.User.Role.List.Service.Abstract
{
    public interface IRoleListRoleService : IKeyedGenericService<RoleListRole>
    {
        IList<RoleListRole> GetAll(string applicationName);
        IPagedResult<RoleListRole> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, RoleListRoleOrderBy orderBy = RoleListRoleOrderBy.Name, SortBy sortBy = SortBy.Asc, int page = 1);
        IMostRecentResult<RoleListRole> GetLatestSince(DateTime datetime, string applicationName);
        IList<RoleListRole> GetMostRecent(int take, string applicationName);
        int Count(string applicationName);
        bool Exists(string name, string applicationName);
    }
}
