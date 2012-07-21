namespace ThreeBytes.Core.Extensions.Image
{
    public static class FileTypeExtensions
    {
        public static string GetFileTypeAsString(this System.Drawing.Image imageIn)
        {
            string fileType = string.Empty;

            if (imageIn.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                fileType = "jpeg";
            if (imageIn.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                fileType = "png";
            if (imageIn.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                fileType = "bmp";
            if (imageIn.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                fileType = "tiff";
            else if (imageIn.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                fileType = "gif";
            else
                fileType = "jpeg";

            return fileType;
        }
    }
}
