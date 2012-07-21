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
    public class CreatedNewsArticleInternalEventMessageHandler : IHandleMessages<ICreatedNewsArticleInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsListNewsArticleService service;
        private readonly INewsListNewsArticleValidatorResolver validatorResolver;

        public CreatedNewsArticleInternalEventMessageHandler(INewsListNewsArticleService service, INewsListNewsArticleValidatorResolver validatorResolver)
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

            string content = message.Content;

            if (content.Length > 200)
                content = message.Content.Substring(0, 200);

            NewsListNewsArticle article = new NewsListNewsArticle
                                         {
                                             Id = message.Id,
                                             CreatedBy = message.CreatedBy,
                                             Title = message.Title,
                                             Content = content
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
