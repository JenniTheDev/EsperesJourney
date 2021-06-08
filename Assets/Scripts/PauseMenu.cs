using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject panel;

    private void Start() {
        pauseMenuUI.SetActive(false);
        panel.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
               if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private void Pause() {
        pauseMenuUI.SetActive(true);
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        EventController.Instance.BroadcastPause();

    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        EventController.Instance.BroadcastResume();
       
    }
}
