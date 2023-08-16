using UnityEngine;

public class CreateFigure : MonoBehaviour
{
    public int[,] Create(int level)
    {
        int numbers_of_cells = NumbersOfCells(level);
        int[,] cells_figure = new int[numbers_of_cells, 2];
        for (int i = 0; i < numbers_of_cells; i++)
        {
            cells_figure[i,0] = -1;
            cells_figure[i,1] = -1;
        }
        int iteration_limiter = 0;
        int[,] fill_cell = FillCell(iteration_limiter, cells_figure, level, numbers_of_cells);
        int[,] ordered_cells = ArrangeCells(fill_cell, level, numbers_of_cells);
        return ordered_cells;
    }
    private int NumbersOfCells(int level)
    {
        var min = (level * level / 2) - level / 2 + 1;
        var max = level * level - level + 1;
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }
    private int[] ChoosingCoordinates(int level)
    {
        System.Random rnd = new System.Random();
        int[] coordinates_XY = new int[2];
        coordinates_XY[0] = rnd.Next(0, level);
        coordinates_XY[1] = rnd.Next(0, level);
        return coordinates_XY;
    }
    private bool DoesExistCell(int[] coordinates_XY, int[,] cells_figure)
    {
        int cells_figure_Length = cells_figure.GetUpperBound(0) + 1;
        for (int i = 0; i < cells_figure_Length; i++)
        {
            if ( coordinates_XY[0]==cells_figure[i,0] && coordinates_XY[1]==cells_figure[i,1])
            {
            return true;
            }
        }
        return false;
    }
    private bool DoNeedToFill(int[,] cells_figure)
    {
        int cells_figure_Length = cells_figure.GetUpperBound(0) + 1;
        for (int i = 0; i < cells_figure_Length; i++)
        {
            if (cells_figure[i, 0] == -1 || cells_figure[i, 1] == -1)
            {
                return true;
            }
        }
        return false;
    }
    private int[,] AddCoordinatesInArray(int[] coordinates_XY, int[,] cells_figure)
    {
        int cells_figure_Length = cells_figure.GetUpperBound(0) + 1;
        for (int i = 0; i < cells_figure_Length; i++)
        {
            if (cells_figure[i, 0] == -1 && cells_figure[i, 1] == -1)
            {
                cells_figure[i, 0] = coordinates_XY[0];
                cells_figure[i, 1] = coordinates_XY[1];
                return cells_figure;
            }
        }
        return cells_figure;
    }
    private int[,] FillCell(int iteration_limiter, int[,] cells_figure, int level, int numbers_of_cells)
    {
        iteration_limiter++;
        if (iteration_limiter < 30)
        {
            int[] coordinates_XY = ChoosingCoordinates(level);
            if (DoesExistCell(coordinates_XY, cells_figure) == true)
            {
                cells_figure = FillCell(iteration_limiter, cells_figure, level, numbers_of_cells);
                return cells_figure;
            }
            else
            {
                cells_figure = AddCoordinatesInArray(coordinates_XY, cells_figure);
                bool DoNeedToContinue = DoNeedToFill(cells_figure);
                if (DoNeedToContinue == true)
                {
                    cells_figure = FillCell(iteration_limiter, cells_figure, level, numbers_of_cells);
                    return cells_figure;
                }
                else
                {
                    return cells_figure;
                }
            }
        }
        else
        {
            return cells_figure;
        }
    }
    private int[,] ArrangeCells(int[,] fill_cell, int level, int numbers_of_cells)
    {
        int[,] result = new int[numbers_of_cells, 2];
        int index = 0;
        for (int y = 0; y < level; y++)
        {
            for (int x = 0; x < level; x++)
            {
                for (int i = 0; i < numbers_of_cells; i++)
                {
                    if (fill_cell[i, 0] == x && fill_cell[i, 1] == y)
                    {
                        result[index, 0] = fill_cell[i, 0];
                        result[index, 1] = fill_cell[i, 1];
                        index++;
                        break;
                    }
                }
            }
        }
        return result;
    }
}