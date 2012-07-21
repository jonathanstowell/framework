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
    public class UpdateNewsArticleContentCommandMessageHandler : IHandleMessages<IUpdateNewsArticleContentCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsManagementNewsArticleService service;
        private readonly INewsManagementNewsArticleValidatorResolver validatorResolver;

        public UpdateNewsArticleContentCommandMessageHandler(INewsManagementNewsArticleService service, INewsManagementNewsArticleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdateNewsArticleContentCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            NewsManagementNewsArticle article = service.GetById(message.Id);

            if (article == null)
                return;

            if (string.Equals(article.Content, message.NewContent))
                return;

            article.Content = message.NewContent;
            article.LastModifiedBy = message.UpdatedBy;

            ValidationResult result = validatorResolver.UpdateContentValidator().Validate(article);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update News Article content", result);
            }

            service.Update(article);

            Bus.PublishAndSendLocal<IUpdatedNewsArticleContentInternalEventMessage>(x =>
            {
                x.Id = article.Id;
                x.NewContent = article.Content;
                x.UpdatedBy = article.LastModifiedBy;
                x.EventDescription = string.Format("{0} updated the content of a news article with the title {1}.", article.LastModifiedBy, article.Title);
            });
        }
    }
}
