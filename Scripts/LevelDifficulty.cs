using UnityEngine;
using TMPro;
using System;

public class LevelDifficulty : MonoBehaviour
{
    private TMP_Text score;
    public int Learn()
    {
        score = GetComponent<TMP_Text>();
        int number = Int32.Parse(score.text);
        int level;
        if (number < 10)
        {
            level = 2;
        } else if (number < 20)
        {
            level = 3;
        } else if (number < 30)
        {
            level = 4;
        } else
        {
            level = 5;
        }
        return level;
    }
}