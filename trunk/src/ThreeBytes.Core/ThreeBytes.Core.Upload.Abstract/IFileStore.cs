using System;
using System.Drawing;
using System.Web;

namespace ThreeBytes.Core.Upload.Abstract
{
    public interface IFileStore
    {
        Image GetImageFile(string filename);

        string SaveTemporaryFile(HttpPostedFileBase fileBase);
        string SaveTemporaryFile(HttpPostedFileBase fileBase, string append);
        string SaveTemporaryFile(HttpPostedFileBase fileBase, Guid identifier);
        string SaveTemporaryFile(HttpPostedFileBase fileBase, Guid identifier, string append);
        string SaveFile(HttpPostedFileBase fileBase);
        string SaveFile(HttpPostedFileBase fileBase, string append);
        string SaveFile(HttpPostedFileBase fileBase, Guid identifier);
        string SaveFile(HttpPostedFileBase fileBase, Guid identifier, string append);


        string SaveTemporaryFile(Image fileBase);
        string SaveTemporaryFile(Image fileBase, Guid identifier);
        string SaveTemporaryFile(Image fileBase, string append);
        string SaveTemporaryFile(Image fileBase, Guid identifier, string append);
        string SaveFile(Image fileBase);
        string SaveFile(Image fileBase, Guid identifier);
        string SaveFile(Image fileBase, string append);
        string SaveFile(Image fileBase, Guid identifier, string append);

        bool MoveTemporaryFileToStored(string filename);

        string GetDiskLocation(string filename);
        string GetTemporaryDiskLocation(string filename);
    }
}
