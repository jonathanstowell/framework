using System;
using System.Net;
using System.Net.Mail;
using ThreeBytes.Core.Email.Abstract;
using ThreeBytes.Core.Email.Configuration.Abstract;

namespace ThreeBytes.Core.Email.Concrete
{
    public class SmtpClientFactory : ISmtpClientFactory
    {
        private ISmtpClient smtpClient;
        private readonly IProvideSmtpSettings smtpSettings;

        public SmtpClientFactory(IProvideSmtpSettings smtpSettings)
        {
            if (smtpSettings == null)
                throw new ArgumentNullException("smtpSettings");

            this.smtpSettings = smtpSettings;
        }

        public ISmtpClient SmtpClient
        {
            get { return smtpClient ?? (smtpClient = InitialiseSmtpClient());}
        }

        private ISmtpClient InitialiseSmtpClient()
        {
            SmtpClient client = new SmtpClient(smtpSettings.Host, smtpSettings.Port);
            client.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);
            client.DeliveryMethod = smtpSettings.DeliveryMethod;
            client.EnableSsl = smtpSettings.EnableSSL;

            if (smtpSettings.DeliveryMethod == SmtpDeliveryMethod.SpecifiedPickupDirectory)
                client.PickupDirectoryLocation = smtpSettings.PickupDirectoryLocation;

            return new SmtpClientWrapper(client);
        }
    }
}
