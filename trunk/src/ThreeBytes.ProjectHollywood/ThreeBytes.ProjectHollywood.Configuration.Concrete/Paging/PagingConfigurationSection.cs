using System.Configuration;

namespace ThreeBytes.ProjectHollywood.Configuration.Concrete.Paging
{
    public class PagingConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty pagingElement =
             new ConfigurationProperty("paging", typeof(PagingCongigurationCollection), null, ConfigurationPropertyOptions.IsRequired);

        public PagingConfigurationSection()
        {
        }

        [ConfigurationProperty("paging", IsRequired = true)]
        public PagingCongigurationCollection Paging
        {
            get { return (PagingCongigurationCollection)this[pagingElement]; }
        }
    }

    [ConfigurationCollection(typeof(PagingEntityConfigElement), AddItemName = "setting",
         CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class PagingCongigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PagingEntityConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PagingEntityConfigElement)element).Entity;
        }

        new public PagingEntityConfigElement this[string entity]
        {
            get { return (PagingEntityConfigElement)BaseGet(entity); }
        }
    }

    public class PagingEntityConfigElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty entity =
            new ConfigurationProperty("entity", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);

        private static readonly ConfigurationProperty pageSize =
            new ConfigurationProperty("pageSize", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);

        public PagingEntityConfigElement()
        {
            base.Properties.Add(entity);
            base.Properties.Add(pageSize);
        }

        [ConfigurationProperty("entity", IsRequired = true)]
        public string Entity
        {
            get { return (string)this[entity]; }
        }

        [ConfigurationProperty("pageSize", IsRequired = true)]
        public string PageSize
        {
            get { return (string)this[pageSize]; }
        }
    }
}
