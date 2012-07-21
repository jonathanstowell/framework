using System;

namespace ThreeBytes.Core.Image.Service.Abstract
{
    public interface IResizeImageService
    {
        string ResizeSavedImage(string filename, Guid identifier, string append, int width, int height);
        string ResizeTemporarySavedImage(string filename, Guid identifier, string append, int width, int height);
    }
}
