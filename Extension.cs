namespace MazeProject
{
    using System.Drawing;
    public static class ColorExtension
    {
        public static bool RBGEqual(this Color myColor, Color color)
        {
            return (myColor.R == color.R) && (myColor.B == color.B) && (myColor.G == color.G);
        }
    }
}