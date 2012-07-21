using System;
using System.Web;
using FluentValidation.Results;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Image.Service.Abstract;
using ThreeBytes.Core.Upload.Abstract;
using ThreeBytes.ProjectHollywood.Host.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Host.Frontend.Commands
{
    public class PersistImageCommand : ICommand
    {
        private readonly IFileStore fileStore;
        private readonly IResizeImageService resizeImageService;
        private readonly IPersistImageValidatorResolver validatorResolver;

        private bool executed;

        public ValidationResult Results { get; set; }

        public HttpPostedFileBase Image { get; set; }
        public Guid Identifier { get; set; }

        public string Filename { get; set; }
        public string ThumbnailName { get; set; }

        public PersistImageCommand(IFileStore fileStore, IResizeImageService resizeImageService, IPersistImageValidatorResolver validatorResolver)
        {
            this.fileStore = fileStore;
            this.resizeImageService = resizeImageService;
            this.validatorResolver = validatorResolver;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Guid identifier = Guid.NewGuid();

                Filename = fileStore.SaveTemporaryFile(Image, identifier);
                ThumbnailName = resizeImageService.ResizeTemporarySavedImage(Filename, identifier, "thumbnail", 260, 180);
            }
        }

        public void Validate()
        {
            Results = validatorResolver.CreateValidator().Validate(Image);
        }

        public bool HasExecuted
        {
            get { return executed; }
        }
    }
}
