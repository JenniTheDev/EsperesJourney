// Brought to you by Jenni
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField] public AudioSource soundtrack;
    [SerializeField] public AudioSource environmentalSFX;
    [SerializeField] public AudioSource espereAudio;
    [SerializeField] public AudioSource enemyAudio;
    [SerializeField] public AudioSource miscAudio;

    #region Soundtracks
    [SerializeField] private AudioClip sewerLevelMusicSound;
    [SerializeField] private AudioClip pauseMusicSound;
    [SerializeField] private AudioClip gameWonSound;
    [SerializeField] private AudioClip sewerAmbiant;
    [SerializeField] private AudioClip mainMenuMusic;

    #endregion

    #region Espere
    [SerializeField] private AudioClip playerDeathSound;
    [SerializeField] private AudioClip dashSound;
    [SerializeField] private AudioClip meleeAttackSound;
    [SerializeField] private AudioClip teleportSound;
    // [SerializeField] private AudioClip rangedAttackSound;
    // [SerializeField] private AudioClip healthPotPickup;


    #endregion

    #region Enemies

    #endregion

    #region Environmental SFX   
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;
    // don't put door fail and door click on the same audio source
    [SerializeField] private AudioClip doorButtonClick;
   

    #endregion

    #region Misc
    [SerializeField] private AudioClip doorFail;
    [SerializeField] private AudioClip bridgeOpen;

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

    #endregion Monobehavior

    #region Methods

    private void PlayLevelMusic() {
        soundtrack.clip = sewerLevelMusicSound;
        soundtrack.Play();
    }

    private void PlayPauseMusic() {
        soundtrack.clip = pauseMusicSound;
        soundtrack.Play();
    }

    private void PlaySewerAmbiantMusic() {
        soundtrack.clip = sewerAmbiant;
        soundtrack.Play();
    }

    private void PlayPlayerDeathMusic() {
        espereAudio.clip = playerDeathSound;
        espereAudio.Play();
    }

    private void PlayMainMenuMusic() {
        soundtrack.clip = mainMenuMusic;
        soundtrack.Play();
    }

    //private void PlayHealthPotPickup() {
    //    environmentalSFX.clip = healthPotPickup;
    //    environmentalSFX.Play();
    //}

    public void PlayDoorOpen() {
        environmentalSFX.clip = doorOpen;
        environmentalSFX.Play();
    }

    public void PlayBridgeOpen() {
        miscAudio.clip = bridgeOpen;
        miscAudio.Play();
    }

    private void PlayDoorClose() {
    }

    private void PlayDoorFail() {
        miscAudio.clip = doorFail;
        miscAudio.Play();
    }

    private void PlayButtonClick() {
        environmentalSFX.clip = doorButtonClick;
        environmentalSFX.Play();
    }

    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnReset += PlayLevelMusic;
        EventController.Instance.OnResume += PlayLevelMusic;
        EventController.Instance.OnPause += PlayPauseMusic;
        EventController.Instance.OnGameOver += PlayPlayerDeathMusic;
        // EventController.Instance.OnHealthPotFind += PlayHealthPotPickup;
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
        // EventController.Instance.OnHealthPotFind -= PlayHealthPotPickup;
        EventController.Instance.OnTriggerUse -= PlayDoorOpen;
        EventController.Instance.OnButtonPushSuccess -= PlayButtonClick;
        EventController.Instance.OnDoorOpen -= PlayDoorOpen;
        EventController.Instance.OnBridgeOpen -= PlayBridgeOpen;
        EventController.Instance.OnKeyComboFail -= PlayDoorFail;

    }

    #endregion Methods
}