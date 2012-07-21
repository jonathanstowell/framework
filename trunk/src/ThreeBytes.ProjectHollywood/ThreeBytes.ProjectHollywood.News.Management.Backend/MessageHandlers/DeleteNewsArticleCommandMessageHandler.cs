using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.News.Messages.Commands;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.News.Management.Backend.MessageHandlers
{
    public class DeleteNewsArticleCommandMessageHandler : IHandleMessages<IDeleteNewsArticleCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsManagementNewsArticleService service;
        private readonly INewsManagementNewsArticleValidatorResolver validatorResolver;

        public DeleteNewsArticleCommandMessageHandler(INewsManagementNewsArticleService service, INewsManagementNewsArticleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IDeleteNewsArticleCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            NewsManagementNewsArticle article = service.GetById(message.Id);

            if (article == null)
                return;

            ValidationResult result = validatorResolver.DeleteValidator().Validate(article);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not delete News Article", result);
            }

            service.Delete(article);

            Bus.PublishAndSendLocal<IDeletedNewsArticleInternalEventMessage>(x =>
                                                       {
                                                           x.Id = article.Id;
                                                           x.DeletedBy = message.DeletedBy;
                                                           x.EventDescription = string.Format("{0} deleted a news article with the title {1}.", message.DeletedBy, article.Title);
                                                       });
        }
    }
}
