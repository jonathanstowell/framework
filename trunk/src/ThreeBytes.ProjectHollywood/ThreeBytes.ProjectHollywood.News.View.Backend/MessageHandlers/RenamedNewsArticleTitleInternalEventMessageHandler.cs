using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.News.View.Entities;
using ThreeBytes.ProjectHollywood.News.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.View.Validations.Abstracts;

namespace ThreeBytes.ProjectHollywood.News.View.Backend.MessageHandlers
{
    public class RenamedNewsArticleTitleInternalEventMessageHandler : IHandleMessages<IRenamedNewsArticleTitleInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsViewNewsArticleService service;
        private readonly INewsViewNewsArticleValidatorResolver validatorResolver;

        public RenamedNewsArticleTitleInternalEventMessageHandler(INewsViewNewsArticleService service, INewsViewNewsArticleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenamedNewsArticleTitleInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            NewsViewNewsArticle oldArticle = service.GetById(message.Id);

            if (oldArticle == null)
                return;

            if (string.Equals(oldArticle.Title, message.NewTitle))
                return;

            NewsViewNewsArticle newArticle = new NewsViewNewsArticle(oldArticle);

            newArticle.Title = message.NewTitle;

            ValidationResult result = validatorResolver.RenameValidator().Validate(newArticle);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update News Article Title", result);
            }

            IHistoricalUpdateOperation<NewsViewNewsArticle> updateOperation = new HistoricalUpdateOperation<NewsViewNewsArticle>
            {
                OldItem = oldArticle,
                NewItem = newArticle,
                OperationDescription = string.Format("Updated Title From {0} to {1}", oldArticle.Title, newArticle.Title)
            };

            service.Update(updateOperation);
        }
    }
}
