namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Configuration.Abstract
{
    public interface IProvideRegistrationStatisticsQuarterlyConfiguration
    {
        bool IsFirstQuarter { get; }
        bool IsSecondQuarter { get; }
        bool IsThirdQuarter { get; }
        bool IsFourthQuarter { get; }
        int GetThisQuarter { get; }
    }
}
