using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Email.Template.List.Entities;
using ThreeBytes.Email.Template.List.Entities.Enums;

namespace ThreeBytes.Email.Template.List.Data.Abstract
{
    public interface IEmailTemplateListTemplateRepository : IKeyedGenericRepository<EmailTemplateListTemplate>
    {
        IList<EmailTemplateListTemplate> GetAll(string applicationName);
        IPagedResult<EmailTemplateListTemplate> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, TemplateListOrderBy orderBy = TemplateListOrderBy.Name, SortBy sortBy = SortBy.Desc, int page = 1);
        IMostRecentResult<EmailTemplateListTemplate> GetLatestSince(DateTime datetime, string applicationName);
        IList<EmailTemplateListTemplate> GetMostRecent(int take, string applicationName);
        int Count(string applicationName);
        bool UniqueTemplate(string name, string applicationName);
    }
}
