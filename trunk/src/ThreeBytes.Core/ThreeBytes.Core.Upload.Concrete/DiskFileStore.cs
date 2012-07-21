using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Hosting;
using ThreeBytes.Core.Extensions.Image;
using ThreeBytes.Core.Upload.Abstract;
using ThreeBytes.Core.Upload.Configuration.Abstract;

namespace ThreeBytes.Core.Upload.Concrete
{
    public class DiskFileStore : IFileStore
    {
        private readonly IDiskFileStoreConfiguration configuration;

        public DiskFileStore(IDiskFileStoreConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Image GetImageFile(string filename)
        {
            try
            {
                string storeDir = GetDiskLocation(filename);

                if (File.Exists(storeDir))
                {
                    return Image.FromFile(storeDir);
                }

                string tempDir = GetTemporaryDiskLocation(filename);

                if (File.Exists(tempDir))
                {
                    return Image.FromFile(tempDir);
                }
            }
            catch (Exception)
            { }

            return null;
        }

        public string SaveTemporaryFile(HttpPostedFileBase fileBase)
        {
            return SaveTemporaryFile(fileBase, Guid.NewGuid(), string.Empty);
        }

        public string SaveTemporaryFile(HttpPostedFileBase fileBase, string append)
        {
            return SaveTemporaryFile(fileBase, Guid.NewGuid(), append);
        }

        public string SaveTemporaryFile(HttpPostedFileBase fileBase, Guid identifier)
        {
            return SaveTemporaryFile(fileBase, identifier, string.Empty);
        }

        public string SaveTemporaryFile(HttpPostedFileBase fileBase, Guid identifier, string append)
        {
            string filename = GetFileName(identifier, append, GetImageFileExtension(fileBase));
            fileBase.SaveAs(GetTemporaryDiskLocation(filename));
            return filename;
        }

        public string SaveTemporaryFile(Image fileBase)
        {
            return SaveTemporaryFile(fileBase, Guid.NewGuid(), string.Empty);
        }

        public string SaveTemporaryFile(Image fileBase, Guid identifier)
        {
            return SaveTemporaryFile(fileBase, identifier, string.Empty);
        }

        public string SaveTemporaryFile(Image fileBase, string append)
        {
            return SaveTemporaryFile(fileBase, Guid.NewGuid(), append);
        }

        public string SaveTemporaryFile(Image fileBase, Guid identifier, string append)
        {
            string filename = GetFileName(identifier, append, GetFileExtension(fileBase));
            fileBase.Save(GetTemporaryDiskLocation(filename));
            return filename;
        }

        public string SaveFile(HttpPostedFileBase fileBase)
        {
            return SaveFile(fileBase, Guid.NewGuid(), string.Empty);
        }

        public string SaveFile(HttpPostedFileBase fileBase, string append)
        {
            return SaveFile(fileBase, Guid.NewGuid(), append);
        }

        public string SaveFile(HttpPostedFileBase fileBase, Guid identifier)
        {
            return SaveFile(fileBase, identifier, string.Empty);
        }

        public string SaveFile(HttpPostedFileBase fileBase, Guid identifier, string append)
        {
            string filename = GetFileName(identifier, append, GetImageFileExtension(fileBase));
            fileBase.SaveAs(GetDiskLocation(filename));
            return filename;
        }

        public string SaveFile(Image fileBase)
        {
            return SaveFile(fileBase, Guid.NewGuid(), string.Empty);
        }

        public string SaveFile(Image fileBase, Guid identifier)
        {
            return SaveFile(fileBase, identifier, string.Empty);
        }

        public string SaveFile(Image fileBase, string append)
        {
            return SaveFile(fileBase, Guid.NewGuid(), append);
        }

        public string SaveFile(Image fileBase, Guid identifier, string append)
        {
            string filename = GetFileName(identifier, append, GetFileExtension(fileBase));
            fileBase.Save(GetDiskLocation(filename));
            return filename;
        }

        public bool MoveTemporaryFileToStored(string filename)
        {
            string tempDir = GetTemporaryDiskLocation(filename);
            string storeDir = GetDiskLocation(filename);

            try
            {
                if (!File.Exists(tempDir))
                    return false;

                if (File.Exists(storeDir))
                    File.Delete(storeDir);

                File.Copy(tempDir, storeDir);

                if (File.Exists(storeDir))
                {
                    return true;
                }

                if (File.Exists(tempDir))
                {
                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetDiskLocation(string filename)
        {
            if (configuration == null)
                throw new NullReferenceException("configuration");

            return Path.Combine(HostingEnvironment.MapPath(string.Format("~/{0}", configuration.Directory)), filename);
        }

        public string GetTemporaryDiskLocation(string filename)
        {
            if (configuration == null)
                throw new NullReferenceException("configuration");

            return Path.Combine(HostingEnvironment.MapPath(string.Format("~/{0}", configuration.TemporaryDirectory)), filename);
        }

        private string GetFileName(Guid identifier, string append, string fileType)
        {
            if (string.IsNullOrEmpty(append))
                return string.Format("{0}.{1}", identifier, fileType);

            return string.Format("{0}-{1}.{2}", identifier, append, fileType);
        }

        private string GetImageFileExtension(HttpPostedFileBase fileBase)
        {
            Image image = Image.FromStream(fileBase.InputStream, true, true);
            return GetFileExtension(image);
        }

        private string GetFileExtension(Image fileBase)
        {
            return fileBase.GetFileTypeAsString();
        }
    }
}
