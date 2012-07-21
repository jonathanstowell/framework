using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.News.Messages.Commands;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.PreCommands
{
    public class CreatedNewsArticlePreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        private readonly INewsManagementNewsArticleValidatorResolver validatorResolver;
        private bool executed;

        public CreatedNewsArticlePreCommand(IBus bus, INewsManagementNewsArticleValidatorResolver validatorResolver)
        {
            if (bus == null)
                throw new ArgumentNullException("bus");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            Bus = bus;
            this.validatorResolver = validatorResolver;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<ICreateNewsArticleCommandMessage>(x =>
                {
                    x.CreatedBy = CreatedBy;
                    x.Title = Title;
                    x.Content = Content;
                });
            }
        }

        public void Validate()
        {
            NewsManagementNewsArticle article = new NewsManagementNewsArticle
            {
                CreatedBy = CreatedBy,
                Title = Title,
                Content = Content
            };

            Results = validatorResolver.CreateValidator().Validate(article);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
