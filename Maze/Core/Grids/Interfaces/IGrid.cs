namespace maze.Core.Grids.Interfaces {
    using System;
    using System.Drawing;

    using maze.Core.Cells;

    public interface IGrid {
        Cell RandomCell(Random random = null);
        Cell this[int row, int column] { get; }
        int Rows { get; }
        int Columns { get; }
        Image ToImg(int cellSize = 50, float insetPrc = 0.0f);
        void Braid(double p = 1.0f);
    }
}