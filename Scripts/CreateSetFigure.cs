using UnityEngine;

public class CreateSetFigure : MonoBehaviour
{
    public GameObject testGameObj;
    public int[][,] Create(int level)
    {
        int numbers_of_figures = level * level;
        int[][,] set_figures = new int[numbers_of_figures][,];
        int iteration_limiter = 0;
        int[][,] result_set = FillSetFigures(iteration_limiter, level, numbers_of_figures, set_figures);
        return result_set;
    }
    private bool DoesExistFigure(int numbers_of_figures, int[][,] set_figures, int[,] figure)
    {
        int figure_check_Length = figure.GetUpperBound(0) + 1;
        for (int f = 0; f < numbers_of_figures; f++)
        {
            if (set_figures[f]==null) continue;
            int cells_figures_Length = set_figures[f].GetUpperBound(0) + 1;
            if (figure_check_Length != cells_figures_Length) continue;
            int number_matches = 0;
            for (int i = 0; i < cells_figures_Length; i++)
            {
                if ( set_figures[f][i,0]==figure[i,0] && set_figures[f][i,1]==figure[i,1] ) number_matches++;
            }
            if (number_matches == cells_figures_Length) return true;
        }
        return false;
    }
    private int[][,] AddFigureInSet(int numbers_of_figures, int[,] figure, int[][,] set_figures)
    {
        for (int f = 0; f < numbers_of_figures; f++)
        {
            if (set_figures[f] != null) continue;
            set_figures[f] = figure;
            return set_figures;
        }
        Debug.Log("Error CreateSetFigure.AddFigureInSet: method don't add value");
        return set_figures;
    }
    private bool DoNeedToFill(int numbers_of_figures, int[][,] set_figures)
    {
        for (int f = 0; f < numbers_of_figures; f++)
        {
            if (set_figures[f] == null) return true;
        }
        return false;
    }
    private int[][,] FillSetFigures(int iteration_limiter, int level, int numbers_of_figures, int[][,] set_figures)
    {
        iteration_limiter++;
        if (iteration_limiter < 30)
        {
            int[,] figure = testGameObj.GetComponent<CreateFigure>().Create(level);
            if (DoesExistFigure(numbers_of_figures, set_figures, figure) == true)
            {
                set_figures = FillSetFigures(iteration_limiter, level, numbers_of_figures, set_figures);
                return set_figures;
            }
            else
            {
                set_figures = AddFigureInSet(numbers_of_figures, figure, set_figures);
                bool DoNeedToContinue = DoNeedToFill(numbers_of_figures, set_figures);
                if (DoNeedToContinue == true)
                {
                    set_figures = FillSetFigures(iteration_limiter, level, numbers_of_figures, set_figures);
                    return set_figures;
                }
                else
                {
                    return set_figures;
                }
            }
        }
        else
        {
            return set_figures;
        }
    }
}