using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.ProjectHollywood.News.View.Entities
{
    [Serializable]
    public class NewsViewNewsArticle : HistoricBusinessObject<NewsViewNewsArticle>, IHistoricBusinessObject<NewsViewNewsArticle>
    {
        public virtual string CreatedBy { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }

        public NewsViewNewsArticle()
        {}

        public NewsViewNewsArticle(NewsViewNewsArticle article)
        {
            CreatedBy = article.CreatedBy;
            Title = article.Title;
            Content = article.Content;
            ItemId = article.ItemId;
        }
    }
}
