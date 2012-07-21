namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Configuration.Abstract
{
    public interface IProvideEmailDispatchQuarterlyConfiguration
    {
        bool IsFirstQuarter { get; }
        bool IsSecondQuarter { get; }
        bool IsThirdQuarter { get; }
        bool IsFourthQuarter { get; }
        int GetThisQuarter { get; }
    }
}
