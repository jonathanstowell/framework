using System;
using System.Net.Mail;

namespace ThreeBytes.Core.Email.Abstract
{
    public interface ISmtpClient : IDisposable
    {
        void Send(MailMessage message);
    }
}
