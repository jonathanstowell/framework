using FluentNHibernate.Mapping;

namespace ThreeBytes.ProjectHollywood.News.List.Entities.Mappings.FluentNHibernateMaps
{
    public class NewsListNewsArticleMapping : ClassMap<NewsListNewsArticle>
    {
        public NewsListNewsArticleMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("NewsArticleId");

            Map(x => x.Title).Length(100).Not.Nullable();
            Map(x => x.Content).Column("[Content]").Length(200).Not.Nullable();

            Map(x => x.CreatedBy).Not.Nullable().Length(35);
            Map(x => x.LastModifiedBy).Nullable().Length(35);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("NewsListNewsArticles");
        }
    }
}
