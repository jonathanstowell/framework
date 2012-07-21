using System;
using System.Drawing;
using System.Web;
using FluentValidation;

namespace ThreeBytes.ProjectHollywood.Host.Validations.Concrete.Validators
{
    public class PersistImageValidator : AbstractValidator<HttpPostedFileBase>
    {
        public PersistImageValidator()
        {
            RuleFor(x => x).NotNull().OverridePropertyName("ProfileImageLocation");
            RuleFor(x => x).Must(IsAnImage).OverridePropertyName("ProfileImageLocation").WithMessage("File must be an image of the following types jpg, jpeg, png, bmp, tiff, gif.");
        }

        private bool IsAnImage(HttpPostedFileBase postedFile)
        {
            try
            {
                Image image = Image.FromStream(postedFile.InputStream);

                if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) ||
                    image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png) ||
                    image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp) ||
                    image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff) ||
                    image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
