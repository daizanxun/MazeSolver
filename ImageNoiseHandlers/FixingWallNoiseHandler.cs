namespace MazeProject.ImageNoiseHandlers
{
    using System;
    using System.Drawing;

    public class FixingWallNoiseHandler : IImageNoiseHandler<Image>
    {
        private Color _wallColor;
        public FixingWallNoiseHandler(Color wallColor)
        {
            _wallColor = wallColor;
        }

        public Image Handle(Image img)
        {
            var bitmap = ImageHelper.ConvertToBitmap(img);
            return FixWall(bitmap);
        }

        private Bitmap FixWall(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }
    }
}
