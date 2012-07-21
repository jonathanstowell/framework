using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.ProjectHollywood.News.Management.Entities
{
    [Serializable]
    public class NewsManagementNewsArticle : BusinessObject<NewsManagementNewsArticle>, IBusinessObject<NewsManagementNewsArticle>
    {
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
    }
}
