using System;
using System.Net.Mail;
using ThreeBytes.Core.Concrete;
using ThreeBytes.Core.Email.Abstract;

namespace ThreeBytes.Core.Email.Concrete
{
    public class SmtpClientWrapper : Disposable, ISmtpClient
    {
        private readonly SmtpClient smtpClient;

        public SmtpClientWrapper(SmtpClient smtpClient)
        {
            if (smtpClient == null)
                throw new ArgumentNullException("smtpClient");

            this.smtpClient = smtpClient;
        }

        public void Send(MailMessage message)
        {
            smtpClient.Send(message);
        }
    }
}
