namespace MazeProject.Mazes.MazeSolver
{
    using System.Drawing;
    using System.Collections.Generic;

    public abstract class ImageMazeSolverBase<TMaze>
        where TMaze : IImageMaze
    {
        protected readonly TMaze Maze;
        protected readonly IImageMazeAlgrithm Solver;

        protected readonly IImageNoiseProcessor<Image> _noiseProcessor;

        protected ImageMazeSolverBase(TMaze maze, IImageMazeAlgrithm solver)
        {
            Maze = maze;
            Solver = solver;
        }

        protected abstract IEnumerable<IImageNoiseHandler<Image>> GetNoiseHandlers();

        public virtual IEnumerable<Pixel> Solve()
        {
            var noiseProcessor = new ImageNoiseProcessor(GetNoiseHandlers());

            noiseProcessor.Process(Maze.MazeImage);

            return Solver.GetSolutionPath(Maze);
        }
    }
}
