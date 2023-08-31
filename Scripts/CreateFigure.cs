using UnityEngine;

public class CreateFigure : MonoBehaviour
{
    public int[,] Create(int level)
    {
        int numbersOfSquares = GetNumbersOfSquares(level);
        int[,] squaresOfFigure = new int[numbersOfSquares, 2];
        for (int i = 0; i < numbersOfSquares; i++)
        {
            squaresOfFigure[i,0] = -1;
            squaresOfFigure[i,1] = -1;
        }
        int limiterOfIteration = 0;
        int[,] filledFigure = FillFigureWithSquares(limiterOfIteration, squaresOfFigure, level, numbersOfSquares);
        int[,] sortedSqueresOfFigure = SortSquaresOfFigure(filledFigure, level, numbersOfSquares);
        return sortedSqueresOfFigure;
    }
    private int GetNumbersOfSquares(int level)
    {
        var min = (level * level / 2) - level / 2 + 1;
        var max = level * level - level + 1;
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }
    private int[] ChooseCoordinatesOfSquares(int level)
    {
        System.Random rnd = new System.Random();
        int[] coordinatesXY = new int[2];
        coordinatesXY[0] = rnd.Next(0, level);
        coordinatesXY[1] = rnd.Next(0, level);
        return coordinatesXY;
    }
    private bool DoesExistSquare(int numbersOfSquares, int[] coordinatesXY, int[,] squaresOfFigure)
    {
        for (int i = 0; i < numbersOfSquares; i++)
        {
            if (coordinatesXY[0]==squaresOfFigure[i,0] && coordinatesXY[1]==squaresOfFigure[i,1])
            {
            return true;
            }
        }
        return false;
    }
    private bool DoNeedToFill(int numbersOfSquares, int[,] squaresOfFigure)
    {
        for (int i = 0; i < numbersOfSquares; i++)
        {
            if (squaresOfFigure[i, 0] == -1 || squaresOfFigure[i, 1] == -1)
            {
                return true;
            }
        }
        return false;
    }
    private int[,] AddSquareInFigure(int numbersOfSquares, int[] coordinatesXY, int[,] squaresOfFigure)
    {
        for (int i = 0; i < numbersOfSquares; i++)
        {
            if (squaresOfFigure[i, 0] == -1 && squaresOfFigure[i, 1] == -1)
            {
                squaresOfFigure[i, 0] = coordinatesXY[0];
                squaresOfFigure[i, 1] = coordinatesXY[1];
                return squaresOfFigure;
            }
        }
        return squaresOfFigure;
    }
    private int[,] FillFigureWithSquares(int limiterOfIteration, int[,] squaresOfFigure, int level, int numbersOfSquares)
    {
        limiterOfIteration++;
        if (limiterOfIteration < 30)
        {
            int[] coordinates_XY = ChooseCoordinatesOfSquares(level);
            if (DoesExistSquare(numbersOfSquares, coordinates_XY, squaresOfFigure) == true)
            {
                squaresOfFigure = FillFigureWithSquares(limiterOfIteration, squaresOfFigure, level, numbersOfSquares);
                return squaresOfFigure;
            }
            else
            {
                squaresOfFigure = AddSquareInFigure(numbersOfSquares, coordinates_XY, squaresOfFigure);
                if (DoNeedToFill(numbersOfSquares, squaresOfFigure) == true)
                {
                    squaresOfFigure = FillFigureWithSquares(limiterOfIteration, squaresOfFigure, level, numbersOfSquares);
                    return squaresOfFigure;
                }
                else
                {
                    return squaresOfFigure;
                }
            }
        }
        else
        {
            return squaresOfFigure;
        }
    }
    private int[,] SortSquaresOfFigure(int[,] filledFigure, int level, int numbersOfSquares)
    {
        int[,] result = new int[numbersOfSquares, 2];
        int index = 0;
        for (int y = 0; y < level; y++)
        {
            for (int x = 0; x < level; x++)
            {
                for (int i = 0; i < numbersOfSquares; i++)
                {
                    if (filledFigure[i, 0] == x && filledFigure[i, 1] == y)
                    {
                        result[index, 0] = filledFigure[i, 0];
                        result[index, 1] = filledFigure[i, 1];
                        index++;
                        break;
                    }
                }
            }
        }
        return result;
    }
}