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
            var pt = $"{ResourceAssembly.GetNamespace}Images.Icons.{name}";
            var stream = ResourceAssembly.GetAssembly.GetManifestResourceStream(pt);

            var image = new BitmapImage();

            // Construct and return image.
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            // Return constructed BitmapImage.
            return image;
        }
        #endregion
    }
}
