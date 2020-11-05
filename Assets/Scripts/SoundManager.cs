// brought to you by Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private AudioSource pauseMusic;
    [SerializeField] private AudioSource gameOver;
    // menu music? 
    

    #region Monobehavior

    private void Start() {
        Subscribe();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }
    #endregion

    #region Methods

    private void PlayLevelMusic() {
        levelMusic.Play();
    }

    private void PlayPauseMusic() {
        pauseMusic.Play();
    }

    private void PlayGameOverMusic() {
        gameOver.Play();
    }

    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnResume += PlayLevelMusic;
        EventController.Instance.OnPause += PlayPauseMusic;
        EventController.Instance.OnGameOver += PlayGameOverMusic;
    }

    private void Unsubscribe() {
        EventController.Instance.OnResume -= PlayLevelMusic;
        EventController.Instance.OnPause -= PlayPauseMusic;
        EventController.Instance.OnGameOver -= PlayGameOverMusic;
    }
    #endregion





}
