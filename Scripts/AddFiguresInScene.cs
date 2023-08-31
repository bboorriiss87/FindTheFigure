using UnityEngine;

public class AddFiguresInScene : MonoBehaviour
{
    public GameObject scoreNumber;
    public GameObject testGameObj;
    public GameObject square;
    public void AddFigures()
    {
        int level = scoreNumber.GetComponent<LevelDifficulty>().GetLevel();
        float[] grid = GetGrid(level);
        float[] coordMainFigure = new float[2];
        coordMainFigure[0] = grid[0];
        coordMainFigure[1] = grid[1];
        int[][,] allFigures = testGameObj.GetComponent<CreateSetFigure>().Create(level);
        int idMainFigure = testGameObj.GetComponent<ChoosingTrueFigure>().Choosing(level);
        int[,] mainFigure = allFigures[idMainFigure];
        Display(grid[2], coordMainFigure, grid[3], mainFigure);
        float[] coordFirstFigure = new float[2];
        coordFirstFigure[0] = grid[4];
        coordFirstFigure[1] = grid[5];
        int numbersOfFigures = level * level;
        for (int i = 0; i < numbersOfFigures; i++)
        {
            float[] coordFigure = GetCoordFigure(level, coordFirstFigure, i, grid[6]);
            Display(grid[6], coordFigure, grid[7], allFigures[i]);
        }
    }
    private float[] GetGrid(int level)
    {
        float sizeFigureInSet = 5.6f / ( level*2 + 1 );
        float sizeSquaresOfFigureInSet = sizeFigureInSet / level;
        float sizeMainFigure = 1.5f;
        float sizeSquaresMainFigure = sizeMainFigure / level;
        float coordMainFigure_X = 0f;
        float coordMainFigure_Y = 2.25f;
        float coordFirstFigureInSet_X = -2.8f + sizeFigureInSet*1.5f;
        float coordFirstFigureInSet_Y = 0.5f;
        float[] numbers =
        {
            coordMainFigure_X,
            coordMainFigure_Y,
            sizeMainFigure,
            sizeSquaresMainFigure,
            coordFirstFigureInSet_X,
            coordFirstFigureInSet_Y,
            sizeFigureInSet,
            sizeSquaresOfFigureInSet
        };
        return numbers;
    }
    private float[] GetCoordFigure(int level, float[] coordFirstFigure, int numberFigure, float sizeFigure)
    {
        int X, Y = 0;
        float[] coordinates_XY = { 0f, 0f };
        float step = sizeFigure * 2;
        while (true)
        {
            if (numberFigure - level >= 0)
            {
                Y++;
                numberFigure = numberFigure - level;
            }
            else
            {
                X = numberFigure;
                break;
            }
        }
        coordinates_XY[0] = coordFirstFigure[0] + X*step;
        coordinates_XY[1] = coordFirstFigure[1] - Y*step;
        return coordinates_XY;
    }
    private void Display(float sizeFigure, float[] coordFigure, float sizeSquare, int[,] coordSquares)
    {
        square.transform.localScale = new Vector3(sizeFigure, sizeFigure, 1);
        square.GetComponent<SpriteRenderer>().color = new Color(0.85f, 0.85f, 0.85f, 1f);
        Instantiate(square, new Vector3(coordFigure[0], coordFigure[1], 0), Quaternion.identity);
        int numberElement = coordSquares.GetUpperBound(0) + 1;
        float center_X = coordFigure[0] - sizeFigure / 2;
        float center_Y = coordFigure[1] + sizeFigure / 2;
        for (int i = 0; i < numberElement; i++)
        {
            float coord_X = center_X + sizeSquare / 2 + sizeSquare * coordSquares[i,0];
            float coord_Y = center_Y - sizeSquare / 2 - sizeSquare * coordSquares[i,1];
            square.transform.localScale = new Vector3(sizeSquare, sizeSquare, 1);
            square.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.65f, 0.32f, 1f);
            Instantiate(square, new Vector3(coord_X, coord_Y, 0), Quaternion.identity);
        }
    }
    private void Start()
    {
        AddFigures();
    }
}