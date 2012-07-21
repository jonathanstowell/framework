namespace ThreeBytes.User.Dashboard.LoginStatisticsQuarterly.Configuration.Abstract
{
    public interface IProvideLoginStatisticsQuarterlyConfiguration
    {
        bool IsFirstQuarter { get; }
        bool IsSecondQuarter { get; }
        bool IsThirdQuarter { get; }
        bool IsFourthQuarter { get; }
        int GetThisQuarter { get; }
    }
}
