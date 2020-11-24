// Brought to you by Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    #region Game Audio
    // these sounds would originate from one direction
    [SerializeField] private AudioSource sewerLevelMusic;
    [SerializeField] private AudioClip sewerLevelMusicSound;
    [SerializeField] private AudioSource pauseMusic;
    [SerializeField] private AudioClip pauseMusicSound;
    [SerializeField] private AudioSource playerDeath;
    [SerializeField] private AudioClip playerDeathSound;

    #endregion

    // These sounds need to come from the player
    // The AudioSource should be on the object it sounds like it is coming from
    #region Sound Effects
    // [SerializeField] private AudioSource dashSound;
    // [SerializeField] private AudioSource meleeAttackSound;
    // [SerializeField] private AudioSource teleportSound;
    // [SerializeField] private AudioSource rangedAttackSound;
    [SerializeField] private AudioSource healthPotPickup;
    [SerializeField] private AudioClip healthPotPickupSound;
    // [SerializeField] private AudioSource healthPotUse;
    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource doorClose;
    [SerializeField] private AudioSource doorFail;
    [SerializeField] private AudioSource doorButtonClick;
    [SerializeField] private AudioSource bridgeOpen;





    #endregion

    #region Enemy Audio

    #endregion


    #region Monobehavior

    private void Start() {
        Subscribe();
        PlayLevelMusic();
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
        sewerLevelMusic.Play();
    }

    private void PlayPauseMusic() {
        pauseMusic.Play();
    }

    private void PlayPlayerDeathMusic() {
        playerDeath.Play();
    }

    private void PlayHealthPotPickup() {
        healthPotPickup.clip = healthPotPickupSound;
        healthPotPickup.Play();
    }

    public void PlayDoorOpen() {
        doorOpen.Play();
    }
    public void PlayBridgeOpen() {
        bridgeOpen.Play();
    }

    private void PlayDoorClose() {

    }

    private void PlayDoorFail() {
        doorFail.Play();
    }

    private void PlayButtonClick() {
        doorButtonClick.Play();
    }



    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnReset += PlayLevelMusic;
        EventController.Instance.OnResume += PlayLevelMusic;
        EventController.Instance.OnPause += PlayPauseMusic;
        EventController.Instance.OnGameOver += PlayPlayerDeathMusic;
        EventController.Instance.OnHealthPotFind += PlayHealthPotPickup;
        EventController.Instance.OnTriggerUse += PlayDoorOpen;
        EventController.Instance.OnButtonPushSuccess += PlayButtonClick;
        EventController.Instance.OnDoorOpen += PlayDoorOpen;
        EventController.Instance.OnBridgeOpen += PlayBridgeOpen;
        EventController.Instance.OnKeyComboFail += PlayDoorFail;
    }

    private void Unsubscribe() {
        EventController.Instance.OnReset -= PlayLevelMusic;
        EventController.Instance.OnResume -= PlayLevelMusic;
        EventController.Instance.OnPause -= PlayPauseMusic;
        EventController.Instance.OnGameOver -= PlayPlayerDeathMusic;
        EventController.Instance.OnHealthPotFind -= PlayHealthPotPickup;
        EventController.Instance.OnTriggerUse -= PlayDoorOpen;
        EventController.Instance.OnButtonPushSuccess -= PlayButtonClick;
        EventController.Instance.OnDoorOpen -= PlayDoorOpen;
        EventController.Instance.OnBridgeOpen -= PlayBridgeOpen;
        EventController.Instance.OnKeyComboFail -= PlayDoorFail;
    }
    #endregion
}