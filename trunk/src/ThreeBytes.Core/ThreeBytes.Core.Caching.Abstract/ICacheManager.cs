using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Caching.Abstract
{
    public interface ICacheManager
    {
        void Add(string key, object item, DateTime dateTime);

        void Add<T>(T cacheItem) where T : class, IBusinessObject<T>;
        void AddHistoric<T>(T cacheItem) where T : class, IHistoricBusinessObject<T>;
        
        void Add<T>(IList<T> cacheItem) where T : class;
        void AddOrdered<T>(IList<T> cacheItem, string orderedBy) where T : class;
        void AddSorted<T>(string sortedBy, IList<T> cacheItem) where T : class;
        void Add<T>(IList<T> cacheItem, string orderedBy, string sortedBy) where T : class;

        void Add<T>(IPagedResult<T> cacheItem) where T : class;
        void AddOrdered<T>(IPagedResult<T> cacheItem, string orderedBy) where T : class;
        void AddSorted<T>(string sortedBy, IPagedResult<T> cacheItem) where T : class;
        void Add<T>(IPagedResult<T> cacheItem, string orderedBy, string sortedBy) where T : class;
        
        void Add<T>(IMostRecentResult<T> cacheItem) where T : class;

        void AddCurrentlyViewingUsers<T>(object id, Type forType, IList<T> cacheItem) where T : class;

        void Replace(string key, object cacheItem, DateTime until);
        void ReplaceCurrentlyViewingUsers<T>(object id, Type forType, IList<T> cacheItem) where T : class;

        T Get<T>(string key) where T : class;
        
        T Get<T>(Guid id) where T : class, IBusinessObject<T>;
        T GetHistoric<T>(Guid id) where T : class, IHistoricBusinessObject<T>;

        IList<T> Get<T>() where T : class;
        IList<T> GetOrdered<T>(string orderedBy) where T : class;
        IList<T> GetSorted<T>(string sortedBy) where T : class;
        IList<T> Get<T>(string orderedBy, string sortedBy) where T : class;

        IList<T> GetCurrentlyViewingUsers<T>(object id, Type forType) where T : class;

        IPagedResult<T> Get<T>(int page, DateTime? originalRequestDateTime) where T : class;
        IPagedResult<T> GetOrdered<T>(int page, DateTime? originalRequestDateTime, string orderedBy) where T : class;
        IPagedResult<T> GetSorted<T>(int page, DateTime? originalRequestDateTime, string sortedBy) where T : class;
        IPagedResult<T> Get<T>(int page, DateTime? originalRequestDateTime, string orderedBy, string sortedBy) where T : class;
        
        IMostRecentResult<T> Get<T>(DateTime originalRequestDateTime) where T : class;
        
        T Fetch<T>(Guid id, Func<T> retrieveData) where T : class, IBusinessObject<T>;
        T FetchHistoric<T>(Guid id, Func<T> retrieveData) where T : class, IHistoricBusinessObject<T>;

        IList<T> Fetch<T>(Func<IList<T>> retrieveData) where T : class;
        IList<T> FetchOrdered<T>(Func<IList<T>> retrieveData, string orderedBy) where T : class;
        IList<T> FetchSorted<T>(Func<IList<T>> retrieveData, string sortedBy) where T : class;
        IList<T> Fetch<T>(Func<IList<T>> retrieveData, string orderedBy, string sortedBy) where T : class;

        IPagedResult<T> Fetch<T>(int page, DateTime? originalRequestDateTime, Func<IPagedResult<T>> retrieveData) where T : class;
        IPagedResult<T> FetchOrdered<T>(int page, DateTime? originalRequestDateTime, string orderedBy, Func<IPagedResult<T>> retrieveData) where T : class;
        IPagedResult<T> FetchSorted<T>(int page, DateTime? originalRequestDateTime, string sortedBy, Func<IPagedResult<T>> retrieveData) where T : class;
        IPagedResult<T> Fetch<T>(int page, DateTime? originalRequestDateTime, string orderedBy, string sortedBy, Func<IPagedResult<T>> retrieveData) where T : class;
        
        IMostRecentResult<T> Fetch<T>(DateTime originalRequestDateTime, Func<IMostRecentResult<T>> retrieveData) where T : class;
        
        void InvalidateCacheItem<T>(T item) where T : class, IBusinessObject<T>;
        void InvalidateHistoricCacheItem<T>(T item) where T : class, IHistoricBusinessObject<T>;
    }
}
