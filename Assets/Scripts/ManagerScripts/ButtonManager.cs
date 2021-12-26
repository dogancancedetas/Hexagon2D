using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    private void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void URL()
    {
        Application.OpenURL("https://youtu.be/FKIg8Hrsu00?t=79");
    }
}
