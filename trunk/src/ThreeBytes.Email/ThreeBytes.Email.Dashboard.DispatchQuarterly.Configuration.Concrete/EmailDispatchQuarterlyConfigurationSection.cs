using System.Configuration;
using System.Linq;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Configuration.Concrete
{
    public class EmailDispatchQuarterlyConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty firstQuarterMonths = new ConfigurationProperty("firstQuarterMonths", typeof(string), "1,2,3");
        private static readonly ConfigurationProperty secondQuarterMonths = new ConfigurationProperty("secondQuarterMonths", typeof(string), "4,5,6");
        private static readonly ConfigurationProperty thirdQuarterMonths = new ConfigurationProperty("thirdQuarterMonths", typeof(string), "7,8,9");
        private static readonly ConfigurationProperty fourthQuarterMonths = new ConfigurationProperty("fourthQuarterMonths", typeof(string), "10,11,12");

        public EmailDispatchQuarterlyConfigurationSection()
        {
            base.Properties.Add(firstQuarterMonths);
            base.Properties.Add(secondQuarterMonths);
            base.Properties.Add(thirdQuarterMonths);
            base.Properties.Add(fourthQuarterMonths);
        }

        public int[] FirstQuarterMonths
        {
            get { return ((string)this[firstQuarterMonths]).Split(',').Select(s => int.Parse(s)).ToArray(); }
        }

        public int[] SecondQuarterMonths
        {
            get { return ((string)this[secondQuarterMonths]).Split(',').Select(s => int.Parse(s)).ToArray(); }
        }

        public int[] ThirdQuarterMonths
        {
            get { return ((string)this[thirdQuarterMonths]).Split(',').Select(s => int.Parse(s)).ToArray(); }
        }

        public int[] FourthQuarterMonths
        {
            get { return ((string)this[fourthQuarterMonths]).Split(',').Select(s => int.Parse(s)).ToArray(); }
        }
    }
}
