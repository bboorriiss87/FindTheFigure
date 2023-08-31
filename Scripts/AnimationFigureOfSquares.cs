using UnityEngine;

public class AnimationFigureOfSquares : MonoBehaviour
{
    public static Color displayColor = new Color(0.2039216f, 0.6588235f, 0.3254902f, 1);
    public static Color hiddenColor = Color.clear;
    public GameObject squareTopRight;
    public GameObject squareBottomRight;
    public GameObject squareBottomLeft;
    public GameObject squareTopLeft;
    public float speed = 2f;
    private float timer;
    public int counter = 0;
    private AnimationFigureOfSquares()
    {
        timer = speed;
    }
    private void SwitchHiddenSquare(int counter)
    {
        squareTopRight.GetComponent<SpriteRenderer>().color = displayColor;
        switch(counter)
        {
            case 0:
                squareTopLeft.GetComponent<SpriteRenderer>().color = displayColor;
                squareTopRight.GetComponent<SpriteRenderer>().color = hiddenColor;
                break;
            case 1:
                squareTopRight.GetComponent<SpriteRenderer>().color = displayColor;
                squareBottomRight.GetComponent<SpriteRenderer>().color = hiddenColor;
                break;
            case 2:
                squareBottomRight.GetComponent<SpriteRenderer>().color = displayColor;
                squareBottomLeft.GetComponent<SpriteRenderer>().color = hiddenColor;
                break;
            case 3:
                squareBottomLeft.GetComponent<SpriteRenderer>().color = displayColor;
                squareTopLeft.GetComponent<SpriteRenderer>().color = hiddenColor;
                break;
        }
    }
    void Start()
    {
        squareTopRight.GetComponent<SpriteRenderer>().color = hiddenColor;
    }
    void Update()
    {
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }
        else
        {
            timer = speed;
            if (counter < 3)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
            SwitchHiddenSquare(counter);
        }
    }
}