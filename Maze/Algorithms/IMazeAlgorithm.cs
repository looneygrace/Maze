namespace maze.Algorithms {
    using maze.Core;
    using maze.Core.Cells;

    public interface IMazeAlgorithm {
        bool Step();
        Cell CurrentCell { get; }
    }
}