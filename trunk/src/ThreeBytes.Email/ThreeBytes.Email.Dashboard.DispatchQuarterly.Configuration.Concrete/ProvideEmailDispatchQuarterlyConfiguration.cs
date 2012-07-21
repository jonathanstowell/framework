using System;
using System.Collections.Generic;
using System.Configuration;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Configuration.Abstract;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Configuration.Concrete
{
    public class ProvideEmailDispatchQuarterlyConfiguration : IProvideEmailDispatchQuarterlyConfiguration
    {
        private readonly EmailDispatchQuarterlyConfigurationSection configManager;

        public ProvideEmailDispatchQuarterlyConfiguration()
        {
            configManager = (EmailDispatchQuarterlyConfigurationSection)ConfigurationManager.GetSection("threeBytesEmailDispatchQuarterly");
        }

        private int CurrentMonth
        {
            get { return DateTime.Today.Month; }
        }

        private int[] FirstQuarterMonths
        {
            get { return configManager.FirstQuarterMonths; }
        }

        private int[] SecondQuarterMonths
        {
            get { return configManager.SecondQuarterMonths; }
        }

        private int[] ThirdQuarterMonths
        {
            get { return configManager.ThirdQuarterMonths; }
        }

        private int[] FourthQuarterMonths
        {
            get { return configManager.FourthQuarterMonths; }
        }

        public bool IsFirstQuarter
        {
            get { return ((IList<int>)FirstQuarterMonths).Contains(CurrentMonth); }
        }

        public bool IsSecondQuarter
        {
            get { return ((IList<int>)SecondQuarterMonths).Contains(CurrentMonth); }
        }

        public bool IsThirdQuarter
        {
            get { return ((IList<int>)ThirdQuarterMonths).Contains(CurrentMonth); }
        }

        public bool IsFourthQuarter
        {
            get { return ((IList<int>)FourthQuarterMonths).Contains(CurrentMonth); }
        }

        public int GetThisQuarter
        {
            get
            {
                if (IsFirstQuarter)
                    return 1;
                if (IsSecondQuarter)
                    return 2;
                if (IsThirdQuarter)
                    return 3;
                if (IsFourthQuarter)
                    return 4;

                return 0;
            }
        }
    }
}
