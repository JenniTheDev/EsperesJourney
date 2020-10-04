// Brought to you by Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    #region Game Audio
    // these sounds would originate from one direction
    [SerializeField] private AudioSource sewerLevelMusic;
    [SerializeField] private AudioSource pauseMusic;
    [SerializeField] private AudioSource playerDeath;
    [SerializeField] private AudioSource menuMusic;
    #endregion

    // These sounds need to come from the player
    #region Sound Effects
    [SerializeField] private AudioSource dashSound;
    [SerializeField] private AudioSource meleeAttackSound;
    [SerializeField] private AudioSource teleportSound;
    [SerializeField] private AudioSource rangedAttackSound;
    [SerializeField] private AudioSource healthPotPickup;
    [SerializeField] private AudioSource healthPotUse;


    #endregion

    #region Enemy Audio

    #endregion


    #region Monobehavior

    private void Start() {
        Subscribe();
        sewerLevelMusic = GetComponent<AudioSource>();
        healthPotPickup = GetComponent<AudioSource>();
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
        sewerLevelMusic = GetComponent<AudioSource>();
        sewerLevelMusic.Play();

    }

    private void PlayPauseMusic() {
        pauseMusic.Play();
    }

    private void PlayPlayerDeathMusic() {
        playerDeath.Play();
    }

    private void PlayHealthPotPickup() {
        healthPotPickup.Play();
    }

    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnResume += PlayLevelMusic;
        EventController.Instance.OnPause += PlayPauseMusic;
        EventController.Instance.OnGameOver += PlayPlayerDeathMusic;
        EventController.Instance.OnHealthPotFind += PlayHealthPotPickup;
    }

    private void Unsubscribe() {
        EventController.Instance.OnResume -= PlayLevelMusic;
        EventController.Instance.OnPause -= PlayPauseMusic;
        EventController.Instance.OnGameOver -= PlayPlayerDeathMusic;
        EventController.Instance.OnHealthPotFind -= PlayHealthPotPickup;
    }
    #endregion





}
