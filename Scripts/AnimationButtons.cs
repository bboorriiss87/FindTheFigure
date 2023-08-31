using UnityEngine;

public class AnimationButtons : MonoBehaviour
{
    public Sprite layerPassive, layerActive;
    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = layerActive;
    }
    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = layerPassive;
    }
}
