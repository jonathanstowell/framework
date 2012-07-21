using System;
using ThreeBytes.Core.Image.Service.Abstract;
using ThreeBytes.Core.Upload.Abstract;

namespace ThreeBytes.Core.Image.Service.Concrete
{
    public class ResizeImageService : IResizeImageService
    {
        private readonly IFileStore fileStore;

        public ResizeImageService(IFileStore fileStore)
        {
            this.fileStore = fileStore;
        }

        public string ResizeSavedImage(string filename, Guid identifier, string append, int width, int height)
        {
            string location = fileStore.GetDiskLocation(filename);
            System.Drawing.Image resized = Resize(location, width, height);
            return fileStore.SaveFile(resized, identifier, append);
        }

        public string ResizeTemporarySavedImage(string filename, Guid identifier, string append, int width, int height)
        {
            string location = fileStore.GetTemporaryDiskLocation(filename);
            System.Drawing.Image resized = Resize(location, width, height);
            return fileStore.SaveTemporaryFile(resized, identifier, append);
        }

        private System.Drawing.Image Resize(string location, int width, int height)
        {
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(location);
                return image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
