using System.Configuration;
using ThreeBytes.SignalR.CurrentlyViewing.Configuration.Abstract;

namespace ThreeBytes.SignalR.CurrentlyViewing.Configuration.Concrete
{
    public class ProvideCurrentlyViewingConfiguration : IProvideCurrentlyViewingConfiguration
    {
        private readonly CurrentlyViewingConfigurationSection configManager;

        public ProvideCurrentlyViewingConfiguration()
        {
            configManager = (CurrentlyViewingConfigurationSection)ConfigurationManager.GetSection("threeBytesCurrentlyViewing");
        }

        public string[] CurrentlyViewingCssColourClasses
        {
            get { return configManager.CssColourClasses; }
        }
    }
}
