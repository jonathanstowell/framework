using System;
using System.Web;
using FluentValidation.Results;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Image.Service.Abstract;
using ThreeBytes.Core.Upload.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Command
{
    public class PersistImageCommand : ICommand
    {
        private readonly IFileStore fileStore;
        private readonly IResizeImageService resizeImageService;
        private bool executed;

        public ValidationResult Results { get; set; }

        public HttpPostedFileBase Image { get; set; }
        public Guid Identifier { get; set; }

        public string Filename { get; set; }
        public string ThumbnailName { get; set; }

        public PersistImageCommand(IFileStore fileStore, IResizeImageService resizeImageService)
        {
            this.fileStore = fileStore;
            this.resizeImageService = resizeImageService;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Guid identifier = Guid.NewGuid();
                Filename = fileStore.SaveFile(Image, identifier);
                ThumbnailName = resizeImageService.ResizeSavedImage(Filename, identifier, "thumbnail", 260, 180);
            }
        }

        public void Validate()
        {
            Results = new ValidationResult();
        }

        public bool HasExecuted
        {
            get { return executed; }
        }
    }
}
