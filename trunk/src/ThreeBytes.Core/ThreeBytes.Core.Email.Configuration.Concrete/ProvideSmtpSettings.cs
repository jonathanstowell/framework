using System.Configuration;
using System.Net.Mail;
using Castle.Windsor.Configuration.Interpreters.XmlProcessor;
using ThreeBytes.Core.Email.Configuration.Abstract;

namespace ThreeBytes.Core.Email.Configuration.Concrete
{
    public class ProvideSmtpSettings : IProvideSmtpSettings
    {
        private readonly EmailConfigurationSection mailSettings;

        public ProvideSmtpSettings()
        {
            mailSettings = ConfigurationManager.GetSection("threeBytesEmail") as EmailConfigurationSection;

            if (mailSettings == null)
                throw new ConfigurationProcessingException("Mail Settings Cannot be Null.");
        }

        public SmtpDeliveryMethod DeliveryMethod
        {
            get
            {
                SmtpDeliveryMethod ret;
                if (SmtpDeliveryMethod.TryParse(mailSettings.DeliveryMethod, out ret))
                    return ret;

                return SmtpDeliveryMethod.SpecifiedPickupDirectory;
            }
        }

        public string Host
        {
            get { return mailSettings.Host; }
        }

        public int Port
        {
            get { return mailSettings.Port; }
        }

        public string Username
        {
            get { return mailSettings.Username; }
        }

        public string Password
        {
            get { return mailSettings.Password; }
        }

        public string From
        {
            get { return mailSettings.From; }
        }

        public string PickupDirectoryLocation
        {
            get { return mailSettings.PickupDirectoryLocation; }
        }

        public bool EnableSSL
        {
            get { return mailSettings.EnableSSL; }
        }
    }
}
