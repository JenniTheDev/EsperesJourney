using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        EventController.Instance.BroadcastGameStart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    { //Credits scene will be last scene in build settings
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void CreditsBack()
    { //Return to Main Menu
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Game has exited.");
        Application.Quit();
    }

}
