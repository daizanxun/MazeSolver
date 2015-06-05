namespace MazeProject.ImageNoiseHandlers
{
    using System;
    using System.Drawing;

    public class GrayStyleHandler : IImageNoiseHandler<Image>
    {
        public Image Handle(Image img)
        {
            var bitmap = ImageHelper.ConvertToBitmap(img);
            return GrayStyleAlgrithm(bitmap);
        }

        private Bitmap GrayStyleAlgrithm(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }
    }
}
