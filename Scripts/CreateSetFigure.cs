using UnityEngine;

public class CreateSetFigure : MonoBehaviour
{
    public GameObject testGameObj;
    public int[][,] Create(int level)
    {
        int numbersOfFigures = level * level;
        int[][,] setOfFigures = new int[numbersOfFigures][,];
        int limiterOfIteration = 0;
        int[][,] finalSet = FillSetOfFigures(limiterOfIteration, level, numbersOfFigures, setOfFigures);
        return finalSet;
    }
    private bool DoesExistFigure(int numbersOfFigures, int[][,] setOfFigures, int[,] figure)
    {
        int numberOfSquaresThisFigure = figure.GetUpperBound(0) + 1;
        for (int f = 0; f < numbersOfFigures; f++)
        {
            if (setOfFigures[f]==null) continue;
            int numberOfSquaresInFigureFromSet = setOfFigures[f].GetUpperBound(0) + 1;
            if (numberOfSquaresThisFigure != numberOfSquaresInFigureFromSet) continue;
            int numberMatches = 0;
            for (int i = 0; i < numberOfSquaresInFigureFromSet; i++)
            {
                if ( setOfFigures[f][i,0]==figure[i,0] && setOfFigures[f][i,1]==figure[i,1] ) numberMatches++;
            }
            if (numberMatches == numberOfSquaresInFigureFromSet) return true;
        }
        return false;
    }
    private int[][,] AddFigureInSet(int numbersOfFigures, int[,] figure, int[][,] setOfFigures)
    {
        for (int f = 0; f < numbersOfFigures; f++)
        {
            if (setOfFigures[f] != null) continue;
            setOfFigures[f] = figure;
            return setOfFigures;
        }
        Debug.Log("Error CreateSetFigure.AddFigureInSet: method don't add value");
        return setOfFigures;
    }
    private bool DoNeedToFill(int numbersOfFigures, int[][,] setOfFigures)
    {
        for (int f = 0; f < numbersOfFigures; f++)
        {
            if (setOfFigures[f] == null) return true;
        }
        return false;
    }
    private int[][,] FillSetOfFigures(int limiterOfIteration, int level, int numbersOfFigures, int[][,] setOfFigures)
    {
        limiterOfIteration++;
        if (limiterOfIteration < 30)
        {
            int[,] figure = testGameObj.GetComponent<CreateFigure>().Create(level);
            if (DoesExistFigure(numbersOfFigures, setOfFigures, figure) == true)
            {
                setOfFigures = FillSetOfFigures(limiterOfIteration, level, numbersOfFigures, setOfFigures);
                return setOfFigures;
            }
            else
            {
                setOfFigures = AddFigureInSet(numbersOfFigures, figure, setOfFigures);
                if (DoNeedToFill(numbersOfFigures, setOfFigures) == true)
                {
                    setOfFigures = FillSetOfFigures(limiterOfIteration, level, numbersOfFigures, setOfFigures);
                    return setOfFigures;
                }
                else
                {
                    return setOfFigures;
                }
            }
        }
        else
        {
            return setOfFigures;
        }
    }
}