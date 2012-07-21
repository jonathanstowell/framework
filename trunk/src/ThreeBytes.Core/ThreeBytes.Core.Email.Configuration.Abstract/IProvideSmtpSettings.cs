using System.Net.Mail;

namespace ThreeBytes.Core.Email.Configuration.Abstract
{
    public interface IProvideSmtpSettings
    {
        SmtpDeliveryMethod DeliveryMethod { get; }
        string Host { get; }
        int Port { get; }
        string Username { get; }
        string Password { get; }
        string From { get; }
        string PickupDirectoryLocation { get; }
        bool EnableSSL { get; }
    }
}
