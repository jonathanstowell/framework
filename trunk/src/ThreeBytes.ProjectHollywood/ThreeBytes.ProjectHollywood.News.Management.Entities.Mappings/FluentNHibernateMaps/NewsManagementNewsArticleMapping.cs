using FluentNHibernate.Mapping;

namespace ThreeBytes.ProjectHollywood.News.Management.Entities.Mappings.FluentNHibernateMaps
{
    public class NewsManagementNewsArticleMapping : ClassMap<NewsManagementNewsArticle>
    {
        public NewsManagementNewsArticleMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("NewsArticleId");

            Map(x => x.Title).Not.Nullable().Length(100);
            Map(x => x.Content).Column("[Content]").Not.Nullable();

            Map(x => x.CreatedBy).Not.Nullable().Length(35);
            Map(x => x.LastModifiedBy).Nullable().Length(35);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("NewsManagementNewsArticles");
        }
    }
}
