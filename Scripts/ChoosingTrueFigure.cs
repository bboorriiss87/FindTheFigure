using UnityEngine;

public class ChoosingTrueFigure : MonoBehaviour
{
    public int Choosing(int level)
    {
        int value = level * level;
        System.Random rnd = new System.Random();
        return rnd.Next(0, value);
    }
}