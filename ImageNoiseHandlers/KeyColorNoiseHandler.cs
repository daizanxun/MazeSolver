namespace MazeProject.ImageNoiseHandlers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class KeyColorNoiseHandler : IImageNoiseHandler<Image>
    {
        private List<Color> _keyColors;
        private Color _replaceColor;

        public KeyColorNoiseHandler(IEnumerable<Color> keyColors, Color replaceColor)
        {
            _keyColors = keyColors.Distinct().ToList();
            if (!_keyColors.Contains(replaceColor, new ColorEqualityComparer()))
                _keyColors.Add(replaceColor);

            _replaceColor = replaceColor;
        }

        public Image Handle(Image img)
        {
            var bitmap = ImageHelper.ConvertToBitmap(img);
            return ReplaceSideColor(bitmap);
        }

        private Bitmap ReplaceSideColor(Bitmap bitmap)
        {
            for (var y = 0; y < bitmap.Height; ++y)
            {
                for (var x = 0; x < bitmap.Width; ++x)
                {
                    if (_keyColors.Any(key => key.RBGEqual(bitmap.GetPixel(x, y))))
                        continue;

                    bitmap.SetPixel(x, y, _replaceColor);
                }
            }

            return bitmap;
        }
    }
}
