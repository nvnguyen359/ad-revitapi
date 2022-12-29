using System;
using System.Windows.Media.Imaging;

namespace AD.Res
{
    public static class ResourceImage
    {
        #region Get path Icon
        /** 
         * <summary>
         * Gets the icon image from reource assembly.
         * </summary>
         */
        public static BitmapImage GetIcon(string name)
        {
            // Create the resource reader stream.
            var pt = $"E:/WPF/ad-revitapi/AD/{ResourceAssembly.GetNamespace}/Images/{name}";
            var stream = ResourceAssembly.GetAssembly1().GetManifestResourceStream(@"E:\\WPF\\ad-revitapi\\AD\\AD.Res\\Images\\tag.png");

            var image = new BitmapImage();

            // Construct and return image.

            Uri uri = new Uri(pt, UriKind.Absolute);
            image.BeginInit();
            image.UriSource = uri;
            image.EndInit();
            // Return constructed BitmapImage.
            return image;
        }
        #endregion
    }
}
