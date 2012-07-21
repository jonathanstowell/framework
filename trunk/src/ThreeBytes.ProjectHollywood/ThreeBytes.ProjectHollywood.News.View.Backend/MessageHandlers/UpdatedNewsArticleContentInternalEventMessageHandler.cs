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
    public class UpdatedNewsArticleContentInternalEventMessageHandler : IHandleMessages<IUpdatedNewsArticleContentInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly INewsViewNewsArticleService service;
        private readonly INewsViewNewsArticleValidatorResolver validatorResolver;

        public UpdatedNewsArticleContentInternalEventMessageHandler(INewsViewNewsArticleService service, INewsViewNewsArticleValidatorResolver validatorResolver)
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

            NewsViewNewsArticle oldArticle = service.GetById(message.Id);

            if (oldArticle == null)
                return;

            if (string.Equals(oldArticle.Content, message.NewContent))
                return;

            NewsViewNewsArticle newArticle = new NewsViewNewsArticle(oldArticle);

            newArticle.Content = message.NewContent;

            ValidationResult result = validatorResolver.UpdateContentValidator().Validate(newArticle);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update News Article content", result);
            }

            IHistoricalUpdateOperation<NewsViewNewsArticle> updateOperation = new HistoricalUpdateOperation<NewsViewNewsArticle>
            {
                OldItem = oldArticle,
                NewItem = newArticle,
                OperationDescription = string.Format("Updated Content From {0} to {1}", oldArticle.Content, newArticle.Content)
            };

            service.Update(updateOperation);
        }
    }
}
