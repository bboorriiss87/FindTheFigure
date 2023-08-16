using UnityEngine;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Main");
    }
}