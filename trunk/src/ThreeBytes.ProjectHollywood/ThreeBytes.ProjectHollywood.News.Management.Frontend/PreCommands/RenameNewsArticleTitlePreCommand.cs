using System;
using FluentValidation.Results;
using NServiceBus;
using SignalR;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.News.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.News.Messages.Commands;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.PreCommands
{
    public class RenameNewsArticleTitlePreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public IConnectionManager ConnectionManager;
        public ValidationResult Results { get; set; }

        public Guid Id { get; set; }
        public string NewTitle { get; set; }
        public string RenamedBy { get; set; }

        private readonly INewsManagementNewsArticleService service;
        private readonly INewsManagementNewsArticleValidatorResolver validatorResolver;
        private bool executed;

        public RenameNewsArticleTitlePreCommand(IBus bus, IConnectionManager connectionManager, INewsManagementNewsArticleValidatorResolver validatorResolver, INewsManagementNewsArticleService service)
        {
            if (bus == null)
                throw new ArgumentNullException("bus");

            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            Bus = bus;
            ConnectionManager = connectionManager;

            this.validatorResolver = validatorResolver;
            this.service = service;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IUpdateArticleTitleCommandMessage>(x => { x.Id = Id; x.NewTitle = NewTitle; x.RenamedBy = RenamedBy; });
                ConnectionManager.GetClients<NewsManagementHub>().handleRenameNewsArticleTitleEventMessage(Id, NewTitle);
            }
        }

        public void Validate()
        {
            NewsManagementNewsArticle article = service.GetById(Id);

            if (article != null)
            {
                article.Title = NewTitle;
                article.LastModifiedBy = RenamedBy;
            }

            Results = validatorResolver.RenameValidator().Validate(article);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
