using MazeSolver.ImageNoiseHandlers;

namespace MazeProject.Mazes.MazeSolver
{
    using System.Collections.Generic;
    using System.Drawing;

    using ImageNoiseHandlers;

    public sealed class StandardMazeSolver : ImageMazeSolverBase<StandardImageMaze>
    {
        public StandardMazeSolver(StandardImageMaze maze, IImageMazeAlgrithm solver)
            : base(maze, solver) { }

        protected override IEnumerable<IImageNoiseHandler<Image>> GetNoiseHandlers()
        {
            // todo : logic to choose noise handler
            // 

            var noiseHandlers = new List<IImageNoiseHandler<Image>>
            {
                // get handler ready to remove colors with not belong to maze elements
                new KeyColorNoiseHandler(new List<Color>
                {
                    Configuration.GetRoadColor(),
                    Configuration.GetEntryColor(),
                    Configuration.GetExitColor(),
                    Configuration.GetWallColor()
                }, Configuration.GetRoadColor()),

                // not implemented noise handlers which can be added to the handler list
                // new GrayStyleHandler(),
                // new FixingWallNoiseHandler(Configuration.GetWallColor())
            };

            return noiseHandlers;
        }
    }
}
