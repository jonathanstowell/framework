using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.News.List.Entities;
using ThreeBytes.ProjectHollywood.News.List.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.News.List.Backend.MessageHandlers
{
    public class DeletedNewsArticleInternalEventMessageHandler : IHandleMessages<IDeletedNewsArticleInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsListNewsArticleService service;
        private readonly INewsListNewsArticleValidatorResolver validatorResolver;

        public DeletedNewsArticleInternalEventMessageHandler(INewsListNewsArticleService service, INewsListNewsArticleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IDeletedNewsArticleInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            NewsListNewsArticle article = service.GetById(message.Id);

            if (article == null)
                return;

            ValidationResult result = validatorResolver.DeleteValidator().Validate(article);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not delete News Article", result);
            }

            service.Delete(article);
        }
    }
}
