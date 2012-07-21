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
    public class CreateNewsArticleCommandMessageHandler : IHandleMessages<ICreateNewsArticleCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsManagementNewsArticleService service;
        private readonly INewsManagementNewsArticleValidatorResolver validatorResolver;

        public CreateNewsArticleCommandMessageHandler(INewsManagementNewsArticleService service, INewsManagementNewsArticleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreateNewsArticleCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            NewsManagementNewsArticle article = new NewsManagementNewsArticle
                                         {
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

            Bus.PublishAndSendLocal<ICreatedNewsArticleInternalEventMessage>(x =>
            {
                x.Id = article.Id;
                x.CreatedBy = article.CreatedBy;
                x.Title = article.Title;
                x.Content = article.Content;
                x.EventDescription = string.Format("{0} created a news article with the title {1}.", article.CreatedBy, article.Title);
            });
        }
    }
}
