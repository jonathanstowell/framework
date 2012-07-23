﻿using System;
using System.Collections.Generic;
using System.Configuration;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Configuration.Abstract;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Configuration.Concrete
{
    public class ProvideRegistrationStatisticsQuarterlyConfiguration : IProvideRegistrationStatisticsQuarterlyConfiguration
    {
        private readonly RegistrationStatisticsQuarterlyConfigurationSection configManager;

        public ProvideRegistrationStatisticsQuarterlyConfiguration()
        {
            configManager = (RegistrationStatisticsQuarterlyConfigurationSection)ConfigurationManager.GetSection("threeBytesUserRegistrationStatisticsQuarterly");
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