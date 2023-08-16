using UnityEngine;

public class AnimationFigureOfSquares : MonoBehaviour
{
    public static Color DisplayColor = new Color(0.2039216f, 0.6588235f, 0.3254902f, 1);
    public static Color HiddenColor = Color.clear;
    public GameObject SquareTopRight;
    public GameObject SquareBottomRight;
    public GameObject SquareBottomLeft;
    public GameObject SquareTopLeft;
    public float speed = 2f;
    private float timer;
    public int counter = 0;
    private AnimationFigureOfSquares()
    {
        timer = speed;
    }
    private void switchHiddenSquare(int counter)
    {
        SquareTopRight.GetComponent<SpriteRenderer>().color = DisplayColor;
        switch(counter)
        {
            case 0:
                SquareTopLeft.GetComponent<SpriteRenderer>().color = DisplayColor;
                SquareTopRight.GetComponent<SpriteRenderer>().color = HiddenColor;
                break;
            case 1:
                SquareTopRight.GetComponent<SpriteRenderer>().color = DisplayColor;
                SquareBottomRight.GetComponent<SpriteRenderer>().color = HiddenColor;
                break;
            case 2:
                SquareBottomRight.GetComponent<SpriteRenderer>().color = DisplayColor;
                SquareBottomLeft.GetComponent<SpriteRenderer>().color = HiddenColor;
                break;
            case 3:
                SquareBottomLeft.GetComponent<SpriteRenderer>().color = DisplayColor;
                SquareTopLeft.GetComponent<SpriteRenderer>().color = HiddenColor;
                break;
        }
    }
    void Start()
    {
        SquareTopRight.GetComponent<SpriteRenderer>().color = HiddenColor;
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
            if(counter<3)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
            switchHiddenSquare(counter);
        }
    }
}