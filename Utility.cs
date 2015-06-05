namespace MazeProject
{
    using System.Collections.Generic;
    using System.Drawing;

    public class ColorEqualityComparer : IEqualityComparer<Color>
    {
        public bool Equals(Color c1, Color c2)
        {
            return (c1.R == c2.R) && (c1.B == c2.B) && (c1.G == c2.G);
        }

        public int GetHashCode(Color color)
        {
            return ((color.R << 4 | color.B) << 4 | color.G).GetHashCode();
        }
    }
}
