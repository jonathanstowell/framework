using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dispatch.List.Data.Abstract;
using ThreeBytes.Email.Dispatch.List.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Dispatch.List.Entities;
using ThreeBytes.Email.Dispatch.List.Entities.Enums;

namespace ThreeBytes.Email.Dispatch.List.Data.Concrete
{
    public class EmailDispatchListEmailMessageRepository : KeyedGenericRepository<EmailDispatchListEmailMessage>, IEmailDispatchListEmailMessageRepository
    {
        public EmailDispatchListEmailMessageRepository(IEmailDispatchListDatabaseFactory databaseFactory, IEmailDispatchListUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public IList<EmailDispatchListEmailMessage> GetAll(string applicationName)
        {
            var entity = Session.QueryOver<EmailDispatchListEmailMessage>()
                .Where(x => x.ApplicationName == applicationName)
                .List();

            return entity;
        }

        public IPagedResult<EmailDispatchListEmailMessage> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, EmailDispatchListOrderBy orderBy = EmailDispatchListOrderBy.CreationDateTime, SortBy sortBy = SortBy.Desc, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            var query = Session.QueryOver<EmailDispatchListEmailMessage>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName);

            switch (orderBy)
            {
                case EmailDispatchListOrderBy.ApplicationName:
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
                case EmailDispatchListOrderBy.From:
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
                case EmailDispatchListOrderBy.To:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.To).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.To).Desc;
                            break;
                    }
                    break;
                case EmailDispatchListOrderBy.CC:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.CC).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.CC).Desc;
                            break;
                    }
                    break;
                case EmailDispatchListOrderBy.BCC:
                    switch (sortBy)
                    {
                        case SortBy.Asc:
                            query = query.OrderBy(x => x.BCC).Asc;
                            break;
                        case SortBy.Desc:
                            query = query.OrderBy(x => x.BCC).Desc;
                            break;
                    }
                    break;
                case EmailDispatchListOrderBy.Subject:
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
                case EmailDispatchListOrderBy.IsHtml:
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
                case EmailDispatchListOrderBy.Encoding:
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
                case EmailDispatchListOrderBy.CreationDateTime:
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
                case EmailDispatchListOrderBy.LastModifiedDateTime:
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

            IList<EmailDispatchListEmailMessage> dispatchedEmails = query.Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<EmailDispatchListEmailMessage>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();

            return new PagedResult<EmailDispatchListEmailMessage>(dispatchedEmails, originalRequest, recordsInThisQuery, page, take);
        }

        public IMostRecentResult<EmailDispatchListEmailMessage> GetLatestSince(DateTime datetime, string applicationName)
        {
            DateTime now = DateTime.Now;

            IList<EmailDispatchListEmailMessage> newestEntities = Session.QueryOver<EmailDispatchListEmailMessage>()
                .Where(x => x.CreationDateTime > datetime)
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .List();

            return new MostRecentResult<EmailDispatchListEmailMessage>(newestEntities, datetime, now);
        }

        public IList<EmailDispatchListEmailMessage> GetMostRecent(int take, string applicationName)
        {
            IList<EmailDispatchListEmailMessage> result = Session.QueryOver<EmailDispatchListEmailMessage>()
                .Where(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }

        public int Count(string applicationName)
        {
            int result = Session.QueryOver<EmailDispatchListEmailMessage>()
                .Where(x => x.ApplicationName == applicationName)
                .RowCount();

            return result;
        }
    }
}
