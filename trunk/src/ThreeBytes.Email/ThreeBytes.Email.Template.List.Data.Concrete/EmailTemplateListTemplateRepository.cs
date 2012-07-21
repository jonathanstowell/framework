using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Template.List.Data.Abstract;
using ThreeBytes.Email.Template.List.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Template.List.Entities;
using ThreeBytes.Email.Template.List.Entities.Enums;

namespace ThreeBytes.Email.Template.List.Data.Concrete
{
    public class EmailTemplateListTemplateRepository : KeyedGenericRepository<EmailTemplateListTemplate>, IEmailTemplateListTemplateRepository
    {
        public EmailTemplateListTemplateRepository(IEmailTemplateListDatabaseFactory databaseFactory, IEmailTemplateListUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public IList<EmailTemplateListTemplate> GetAll(string applicationName)
        {
            var entity = Session.QueryOver<EmailTemplateListTemplate>()
                .Where(x => x.ApplicationName == applicationName)
                .List();

            return entity;
        }

        public IPagedResult<EmailTemplateListTemplate> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, TemplateListOrderBy orderBy = TemplateListOrderBy.Name, SortBy sortBy = SortBy.Desc, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            var query = Session.QueryOver<EmailTemplateListTemplate>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName);

            switch (orderBy)
            {
                case TemplateListOrderBy.ApplicationName:
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
                case TemplateListOrderBy.From:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.From).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.From).Desc;
                            break;
                    }
                    break;
                case TemplateListOrderBy.Name:
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
                case TemplateListOrderBy.Subject:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.Subject).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.Subject).Desc;
                            break;
                    }
                    break;
                case TemplateListOrderBy.IsHtml:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.IsHtml).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.IsHtml).Desc;
                            break;
                    }
                    break;
                case TemplateListOrderBy.Encoding:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.Encoding).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.Encoding).Desc;
                            break;
                    }
                    break;
                case TemplateListOrderBy.CreationDateTime:
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
                case TemplateListOrderBy.LastModifiedDateTime:
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

            IList<EmailTemplateListTemplate> templates = query.Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<EmailTemplateListTemplate>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();

            return new PagedResult<EmailTemplateListTemplate>(templates, originalRequest, recordsInThisQuery, page, take);
        }

        public IMostRecentResult<EmailTemplateListTemplate> GetLatestSince(DateTime datetime, string applicationName)
        {
            DateTime now = DateTime.Now;

            IList<EmailTemplateListTemplate> newestEntities = Session.QueryOver<EmailTemplateListTemplate>()
                .Where(x => x.CreationDateTime > datetime)
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .List();

            return new MostRecentResult<EmailTemplateListTemplate>(newestEntities, datetime, now);
        }

        public IList<EmailTemplateListTemplate> GetMostRecent(int take, string applicationName)
        {
            IList<EmailTemplateListTemplate> result = Session.QueryOver<EmailTemplateListTemplate>()
                .Where(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }

        public int Count(string applicationName)
        {
            int result = Session.QueryOver<EmailTemplateListTemplate>()
               .Where(x => x.ApplicationName == applicationName)
               .RowCount();

            return result;
        }

        public virtual bool UniqueTemplate(string name, string applicationName)
        {
            return Session.QueryOver<EmailTemplateListTemplate>().Where(x => x.Name == name && x.ApplicationName == applicationName).RowCount() == 0;
        }
    }
}
