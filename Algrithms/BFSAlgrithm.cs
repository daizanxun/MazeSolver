namespace MazeProject.Algrithms
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public sealed class BFSAlgrithm : IImageMazeAlgrithm
    {
        private BFSAlgrithm() { }

        public IEnumerable<Pixel> GetSolutionPath(IImageMaze maze)
        {
            return FindPathBfs((Bitmap)maze.MazeImage.Clone(), maze.EntryPixel, maze.ExitPixel, maze.WallColor);
        }

        private IEnumerable<Pixel> FindPathBfs(Bitmap maze, Pixel entry, Pixel exit, Color wallColor)
        {
            List<Pixel> solution = null;
            var queue = new Queue<List<Pixel>>();
            queue.Enqueue(new List<Pixel> { entry });

            while (queue.Any())
            {
                var path = queue.Dequeue();
                var current = path[path.Count - 1];
                if (current.X == exit.X && current.Y == exit.Y)
                {
                    solution = path;
                    break;
                }

                foreach (var neighbor in ImageHelper.GetValidNeighbor(maze, current, new[] { wallColor, Color.Gray }))
                {
                    maze.SetPixel(neighbor.X, neighbor.Y, Color.Gray);
                    var newPath = new List<Pixel>(path) { neighbor };
                    queue.Enqueue(newPath);
                }
            }

            return solution;
        }
    }
}
