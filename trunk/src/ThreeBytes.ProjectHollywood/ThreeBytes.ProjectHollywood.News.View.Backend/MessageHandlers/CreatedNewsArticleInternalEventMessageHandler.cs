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
    public class CreatedNewsArticleInternalEventMessageHandler : IHandleMessages<ICreatedNewsArticleInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsViewNewsArticleService service;
        private readonly INewsViewNewsArticleValidatorResolver validatorResolver;

        public CreatedNewsArticleInternalEventMessageHandler(INewsViewNewsArticleService service, INewsViewNewsArticleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreatedNewsArticleInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            NewsViewNewsArticle article = new NewsViewNewsArticle
                                         {
                                             ItemId = message.Id,
                                             CreatedBy = message.CreatedBy,
                                             Title = message.Title,
                                             Content = message.Content
                                         };

            ValidationResult result = validatorResolver.CreateValidator().Validate(article);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create News Article", result);
            }

            service.Create(article);
        }
    }
}
