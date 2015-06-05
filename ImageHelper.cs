namespace MazeProject
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public static class ImageHelper
    {
        public static Bitmap ConvertToBitmap(Image img)
        {
            if (!img.RawFormat.Equals(ImageFormat.Bmp))
            {
                Stream stream = new MemoryStream();
                img.Save(stream, ImageFormat.Bmp);
                return (Bitmap)Bitmap.FromStream(stream);
            }

            return (Bitmap)img.Clone();
        }

        public static bool CheckConflict(params Color[] colors)
        {
            if (colors.Distinct(new ColorEqualityComparer()).Count() != colors.Count())
                return true;
            return false;
        }

        public static IEnumerable<Pixel> GetValidNeighbor(Bitmap img, Pixel current, IEnumerable<Color> blackListColors)
        {
            return GetNeighbor(current)
                        .Where(neighbor => (neighbor.X < img.Width && neighbor.Y < img.Height && neighbor.X >= 0 && neighbor.Y >= 0)
                                        && (blackListColors.All(blackListColor => !blackListColor.RBGEqual(img.GetPixel(neighbor.X, neighbor.Y)))));
        }

        public static IEnumerable<Pixel> GetNeighbor(Pixel current)
        {
            return new List<Pixel>
            {
                new Pixel(current.X - 1, current.Y),
                new Pixel(current.X, current.Y - 1),
                new Pixel(current.X + 1, current.Y),
                new Pixel(current.X, current.Y + 1)
            };
        }
    }
}
