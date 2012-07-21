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
    public class RenameNewsArticleTitleCommandMessageHandler : IHandleMessages<IUpdateArticleTitleCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsManagementNewsArticleService service;
        private readonly INewsManagementNewsArticleValidatorResolver validatorResolver;

        public RenameNewsArticleTitleCommandMessageHandler(INewsManagementNewsArticleService service, INewsManagementNewsArticleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdateArticleTitleCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            NewsManagementNewsArticle article = service.GetById(message.Id);

            if (article == null)
                return;

            if (string.Equals(article.Title, message.NewTitle))
                return;

            string originalTitle = article.Title;

            article.Title = message.NewTitle;
            article.LastModifiedBy = message.RenamedBy;

            ValidationResult result = validatorResolver.UpdateContentValidator().Validate(article);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update News Article Title", result);
            }

            service.Update(article);

            Bus.PublishAndSendLocal<IRenamedNewsArticleTitleInternalEventMessage>(x =>
            {
                x.Id = article.Id;
                x.NewTitle = article.Title;
                x.RenamedBy = article.LastModifiedBy;
                x.EventDescription = string.Format("{0} renamed a news article title from {1} to {2}.", article.LastModifiedBy, originalTitle, article.Title);
            });
        }
    }
}
