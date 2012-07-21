using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.ProjectHollywood.News.List.Entities
{
    [Serializable]
    public class NewsListNewsArticle : BusinessObject<NewsListNewsArticle>, IBusinessObject<NewsListNewsArticle>
    {
        public virtual string CreatedBy { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
    }
}
