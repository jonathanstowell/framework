using System;
using System.Net.Mail;
using ThreeBytes.Core.Email.Abstract;

namespace ThreeBytes.Core.Email.Concrete
{
    public class SendEmailResult : ISendEmailResult
    {
        public Exception Exception { get; set; }
        public bool Success { get { return Exception == null; } }
        public MailMessage Message { get; set; }

        public SendEmailResult(MailMessage message)
        {
            Message = message;
        }
    }
}
