using UnityEngine;

public class AnimationButtons : MonoBehaviour
{
    public Sprite layer_passive, layer_active;
    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = layer_active;
    }
    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = layer_passive;
    }
}
