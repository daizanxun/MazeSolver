namespace MazeProject
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Collections.ObjectModel;

    public class ImageNoiseProcessor : IImageNoiseProcessor<Image>
    {
        private readonly IReadOnlyCollection<IImageNoiseHandler<Image>> _noiseHandlerList;

        public ImageNoiseProcessor(IEnumerable<IImageNoiseHandler<Image>> handlers)
        {
            _noiseHandlerList = new ReadOnlyCollection<IImageNoiseHandler<Image>>(handlers.ToList());
        }

        public Image Process(Image image)
        {
            return _noiseHandlerList.Aggregate(image, (current, handler) => handler.Handle(current));
        }
    }
}
