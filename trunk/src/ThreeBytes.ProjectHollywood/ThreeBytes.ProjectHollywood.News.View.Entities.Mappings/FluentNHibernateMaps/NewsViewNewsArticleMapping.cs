using FluentNHibernate.Mapping;

namespace ThreeBytes.ProjectHollywood.News.View.Entities.Mappings.FluentNHibernateMaps
{
    public class NewsViewNewsArticleMapping : ClassMap<NewsViewNewsArticle>
    {
        public NewsViewNewsArticleMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("NewsArticleId");

            Map(x => x.ItemId).Not.Nullable();

            Map(x => x.Title).Length(100).Not.Nullable();
            Map(x => x.Content).Column("[Content]").Not.Nullable();

            Map(x => x.Operation);

            Map(x => x.CreatedBy).Not.Nullable().Length(35);
            Map(x => x.LastModifiedBy).Nullable().Length(35);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("NewsViewNewsArticles");
        }
    }
}
