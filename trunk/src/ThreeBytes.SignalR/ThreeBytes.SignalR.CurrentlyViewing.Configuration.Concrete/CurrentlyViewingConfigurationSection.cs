using System.Configuration;

namespace ThreeBytes.SignalR.CurrentlyViewing.Configuration.Concrete
{
    public class CurrentlyViewingConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty cssColourClasses = new ConfigurationProperty("cssColourClasses", typeof(string), "");

        public CurrentlyViewingConfigurationSection()
        {
            base.Properties.Add(cssColourClasses);
        }

        public string[] CssColourClasses
        {
            get 
            { 
                return ((string)this[cssColourClasses]).Split(','); 
            }
        }
    }
}
