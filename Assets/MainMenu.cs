using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Playgame()
    {
        SceneManager.LoadSceneAsync("ClockCutScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
