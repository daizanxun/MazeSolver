namespace MazeProject
{
    using System.Drawing;
    using System.Collections.Generic;

    public interface IPuzzle {}

    public interface IImageMaze : IPuzzle
    {
        Image MazeImage { get; }
        Pixel EntryPixel { get; }
        Pixel ExitPixel { get; }
        Color WallColor { get; }
        Color RoadColor { get; }
    }

    // this defines the image maze giving entry and exit as color 
    public interface IStandardMaze : IImageMaze
    {
        Color EntryColor { get; }
        Color ExitColor { get; }
    }

    public interface INoiseProcessor {}

    public interface IImageNoiseProcessor<TImage> : INoiseProcessor where TImage : Image
    {
        TImage Process(TImage data);
    }

    public interface INoiseHandler {}

    public interface ILossyHandler : INoiseHandler {}

    public interface IImageNoiseHandler<TImage> : INoiseHandler where TImage : Image
    {
        TImage Handle(TImage image);
    }

    public interface IImageMazeAlgrithm
    {
        IEnumerable<Pixel> GetSolutionPath(IImageMaze maze);
    }
}
