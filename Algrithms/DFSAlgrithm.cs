namespace MazeProject.Algrithms
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public sealed class DFSAlgrithm : IImageMazeAlgrithm
    {
        private DFSAlgrithm() { }

        public IEnumerable<Pixel> GetSolutionPath(IImageMaze maze)
        {
            return FindPathDFS((Bitmap)maze.MazeImage.Clone(), maze.EntryPixel, maze.ExitPixel, maze.WallColor);
        }

        private IEnumerable<Pixel> FindPathDFS(Bitmap maze, Pixel entry, Pixel exit, Color wallColor)
        {
            var solution = new List<Pixel>();
            var stack = new Stack<Pixel>();

            stack.Push(entry);

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                yield return current;

                if (current.X == exit.X && current.Y == exit.Y)
                    break;

                foreach (var neighbour in ImageHelper.GetValidNeighbor(maze, current, new[] { wallColor, Color.Gray }))
                {
                    maze.SetPixel(neighbour.X, neighbour.Y, Color.Gray);
                    stack.Push(neighbour);
                }
            }
        }
    }
}
