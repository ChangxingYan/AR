using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuit : MonoBehaviour
{
    // Start is called before the first frame update
public void PlayGame()
    {
        SceneManager.LoadScene("ImageTracking");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
