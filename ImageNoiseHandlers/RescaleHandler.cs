namespace MazeSolver.ImageNoiseHandlers
{
    using System.Drawing;
    using MazeProject;

    public class RescaleHandler : IImageNoiseHandler<Image>, ILossyHandler
    {
        private double _scale;
        public RescaleHandler(double scale)
        {
            _scale = scale;
        }

        public Image Handle(Image image)
        {
            var scaleWidth = (int)(image.Width * _scale);
            var scaleHeight = (int)(image.Height * _scale);
            return new Bitmap(image, new Size(scaleWidth, scaleHeight));
        }
    }
}
