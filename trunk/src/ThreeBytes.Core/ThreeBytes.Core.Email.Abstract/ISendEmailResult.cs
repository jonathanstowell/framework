using System;
using System.Net.Mail;

namespace ThreeBytes.Core.Email.Abstract
{
    public interface ISendEmailResult
    {
        Exception Exception { get; set; }
        bool Success { get; }
        MailMessage Message { get; set; }
    }
}
