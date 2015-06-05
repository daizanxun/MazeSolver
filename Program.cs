using System;
using System.Collections.Generic;

namespace MazeProject
{
    using System.Drawing;

    using Algrithms;
    using Mazes.MazeSolver;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //var inputFilepath = args[1];
            //var outputFilePath = args[2];

            var inputFilepath = @"C:\Users\Evan\Downloads\Maze\Maze2.png"; //@"C:\Temp\maze1.png"; 
            var outputFilepath = @"C:\Users\Evan\Downloads\Maze\Maze1out2.bmp"; //@"C:\Temp\maze1_out.bmp"; 

            var img = Image.FromFile(inputFilepath);
            var bitmap = ImageHelper.ConvertToBitmap(img);

            // Standard Maze is a maze with color plan, entry color, exit color, wall color, road/background color
            var maze = new StandardImageMaze(bitmap,
                new MazeColorPlan(Configuration.GetRoadColor(), Configuration.GetEntryColor(),
                    Configuration.GetExitColor(), Configuration.GetWallColor()));

            var mazeSolver = new StandardMazeSolver(maze, AlgrithmFactory.CreateObject<BFSAlgrithm>());

            var solution = mazeSolver.Solve();

            if (solution != null)
            {
                Draw(bitmap, solution, Configuration.GetSolutionColor());
                bitmap.Save(outputFilepath);
            }
            else
            {
                throw new ApplicationException("Cannot Solve this Maze!");
            }
        }

        private static void Draw(Bitmap bitmap, IEnumerable<Pixel> pattern, Color color)
        {
            foreach (var pixel in pattern)
            {
                bitmap.SetPixel(pixel.X, pixel.Y, color);
            }
        }
    }
}