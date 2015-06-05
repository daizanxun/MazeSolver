using System;
using System.Drawing;

namespace MazeProject
{
    public class StandardImageMaze : IStandardMaze
    {
        private readonly Bitmap _img;
        private Color _entryColor;
        private Color _exitColor;
        private Color _roadColor;
        private Color _wallColor;

        private Pixel _entryPoint;
        private Pixel _exitPoint;


        Image IImageMaze.MazeImage
        {
            get { return _img; }
        }

        Pixel IImageMaze.EntryPixel
        {
            get
            {
                if (_entryPoint == null)
                    _entryPoint = FindColor(_entryColor);

                return _entryPoint;
            }
        }

        Pixel IImageMaze.ExitPixel
        {
            get
            {
                if (_exitPoint == null)
                    _exitPoint = FindColor(_exitColor);

                return _exitPoint;
            }
        }

        Color IImageMaze.WallColor
        {
            get { return _wallColor; }
        }

        Color IImageMaze.RoadColor
        {
            get { return _roadColor; }
        }

        public StandardImageMaze(Bitmap img)
        {
            _img = img;
            _wallColor = Configuration.GetWallColor();
            _roadColor = Configuration.GetRoadColor();
            _entryColor = Configuration.GetEntryColor();
            _exitColor = Configuration.GetExitColor();
        }

        private Pixel FindColor(Color color)
        {
            for (var x = 0; x < _img.Width; x++)
            {
                for (var y = 0; y < _img.Height; y++)
                {
                    if(_img.GetPixel(x, y).RBGEqual(color))
                        return new Pixel(x, y);
                }
            }
            throw new ArgumentException("Cannot find Color in Img");
        }

        public Color EntryColor
        {
            get { return Configuration.GetEntryColor(); }
        }

        public Color ExitColor
        {
            get { return Configuration.GetEntryColor(); }
        }
    }

    public class MazeColorPlan
    {
        public Color BackgroundColor { get; private set; }
        public Color WallColor { get; private set; }
        public Color EntryColor { get; private set; }
        public Color ExitColor { get; private set; }

        public MazeColorPlan(Color backgroundColor, Color entryColor, Color exitColor, Color wallColor)
        {
            if (ImageHelper.CheckConflict(backgroundColor, entryColor, exitColor, wallColor))
            {
                throw new ArgumentException("There is Conflict in Color Plan!");
            }

            BackgroundColor = backgroundColor;
            EntryColor = entryColor;
            ExitColor = exitColor;
            WallColor = wallColor;
        }
    }

    public class Pixel
    {
        public int X;
        public int Y;

        public Pixel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
