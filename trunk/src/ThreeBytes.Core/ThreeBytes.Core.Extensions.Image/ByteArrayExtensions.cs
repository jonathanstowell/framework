using System.IO;

namespace ThreeBytes.Core.Extensions.Image
{
    public static class ByteArrayExtensions
    {
        public static byte[] ToByteArray(this System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}
