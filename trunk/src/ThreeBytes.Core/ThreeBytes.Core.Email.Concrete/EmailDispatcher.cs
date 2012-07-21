using System;
using System.Collections.Generic;
using System.Net.Mail;
using ThreeBytes.Core.Email.Abstract;

namespace ThreeBytes.Core.Email.Concrete
{
    public class EmailDispatcher : IEmailDispatcher
    {
        private readonly ISmtpClientFactory smtpClientFactory;

        public EmailDispatcher(ISmtpClientFactory smtpClientFactory)
        {
            if (smtpClientFactory == null)
                throw new ArgumentNullException("smtpClientFactory");

            this.smtpClientFactory = smtpClientFactory;
        }

        public ISendBatchEmailResult Dispatch(IList<IEmailMessage> emails)
        {
            ISendBatchEmailResult sendBatchResult = new SendBatchEmailResult();

            foreach (var emailMessage in emails)
            {
                MailMessage message = PopulateMailMessage(emailMessage);
                ISendEmailResult result = Dispatch(message);

                if (result.Success)
                {
                    sendBatchResult.SentResults.Add(result);
                }
                else
                {
                    sendBatchResult.FailedResults.Add(result);
                }
            }

            return sendBatchResult;
        }

        public ISendEmailResult Dispatch(IEmailMessage email)
        {
            MailMessage message = PopulateMailMessage(email);
            return Dispatch(message);
        }
        
        private ISendEmailResult Dispatch(MailMessage message)
        {
            ISendEmailResult result = new SendEmailResult(message);

            try
            {
                smtpClientFactory.SmtpClient.Send(message);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        private MailMessage PopulateMailMessage(IEmailMessage email)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress(email.From);
            message.To.Add(new MailAddress(email.To));
            message.Subject = email.Subject;
            message.Body = email.Body;
            message.Headers.Add("X-SME-AppDomain", AppDomain.CurrentDomain.FriendlyName);
            message.IsBodyHtml = email.IsHtml;

            return message;
        }
    }
}
