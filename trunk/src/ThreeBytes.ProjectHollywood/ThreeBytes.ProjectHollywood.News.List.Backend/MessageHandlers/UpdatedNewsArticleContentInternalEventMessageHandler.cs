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
    public class UpdatedNewsArticleContentInternalEventMessageHandler : IHandleMessages<IUpdatedNewsArticleContentInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsListNewsArticleService service;
        private readonly INewsListNewsArticleValidatorResolver validatorResolver;

        public UpdatedNewsArticleContentInternalEventMessageHandler(INewsListNewsArticleService service, INewsListNewsArticleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedNewsArticleContentInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            NewsListNewsArticle article = service.GetById(message.Id);

            if (article == null)
                return;

            if (string.Equals(article.Content, message.NewContent))
                return;

            article.Content = message.NewContent;

            if (article.Content.Length > 200)
                article.Content = article.Content.Substring(0, 200);

            ValidationResult result = validatorResolver.UpdateContentValidator().Validate(article);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update News Article content", result);
            }

            service.Update(article);
        }
    }
}
