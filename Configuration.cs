namespace MazeProject
{
    using System.Collections.Generic;
    using System.Drawing;

    public static class Configuration
    {
        public static Color GetSolutionColor() { return Color.Green; }
        public static IEnumerable<Color> GetWallColors() { yield return Color.Black; }

        public static Color GetWallColor() { return Color.Black; } 

        // the requirement does say 
        public static Color GetRoadColor() {  return Color.White; }

        public static Color GetEntryColor() { return Color.Red; }

        public static Color GetExitColor() { return Color.Blue; }
    }
}
