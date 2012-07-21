namespace ThreeBytes.Core.Email.Abstract
{
    public interface ISmtpClientFactory
    {
        ISmtpClient SmtpClient { get; }
    }
}
