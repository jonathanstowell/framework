using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.News.View.Entities;
using ThreeBytes.ProjectHollywood.News.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.View.Validations.Abstracts;

namespace ThreeBytes.ProjectHollywood.News.View.Backend.MessageHandlers
{
    public class DeletedNewsArticleInternalEventMessageHandler : IHandleMessages<IDeletedNewsArticleInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsViewNewsArticleService service;
        private readonly INewsViewNewsArticleValidatorResolver validatorResolver;

        public DeletedNewsArticleInternalEventMessageHandler(INewsViewNewsArticleService service, INewsViewNewsArticleValidatorResolver validatorResolver)
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

            NewsViewNewsArticle article = service.GetById(message.Id);

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
