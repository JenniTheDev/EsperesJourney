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
    [SerializeField] private AudioClip takingDamage;
    // [SerializeField] private AudioClip rangedAttackSound;
    // [SerializeField] private AudioClip healthPotPickup;


    #endregion

    #region Enemies
    [SerializeField] private AudioClip bossFire;
    [SerializeField] private AudioClip bossRoar;
    [SerializeField] private AudioClip bossRun;
    [SerializeField] private AudioClip enemyDeath;
    [SerializeField] private AudioClip lizardRun;


    #endregion

    #region Environmental SFX   
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;
    // don't put door fail and door click on the same audio source
    [SerializeField] private AudioClip doorButtonClick;
    [SerializeField] private AudioClip propBreakGlassOrCeramic;
    [SerializeField] private AudioClip propBreakMisc;
    [SerializeField] private AudioClip propBreakWood;



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

    public void PlayLevelMusic() {
        soundtrack.clip = sewerLevelMusicSound;
        soundtrack.Play();
    }

    public void PlayPauseMusic() {
        soundtrack.clip = pauseMusicSound;
        soundtrack.Play();
    }

    public void PlaySewerAmbiantMusic() {
        soundtrack.clip = sewerAmbiant;
        soundtrack.Play();
    }

    public void PlayPlayerDeathMusic() {
        espereAudio.clip = playerDeathSound;
        espereAudio.Play();
    }

    public void PlayMainMenuMusic() {
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

    public void PlayDoorClose() {
        environmentalSFX.clip = doorClose;
        environmentalSFX.Play();
    }

    public void PlayDoorFail() {
        miscAudio.clip = doorFail;
        miscAudio.Play();
    }

    public void PlayButtonClick() {
        environmentalSFX.clip = doorButtonClick;
        environmentalSFX.Play();
    }

    private void PlayEspereDeath() {
        espereAudio.clip= playerDeathSound;
        espereAudio.Play();
    }

    private void PlayEspereMeleeAttack() {
        espereAudio.clip = meleeAttackSound;
        espereAudio.Play();
    }

    private void PlayEspereDash() {
        espereAudio.clip = dashSound;
        espereAudio.Play();
    }

    //[SerializeField] private AudioClip bossFire;
    //[SerializeField] private AudioClip bossRoar;
    //[SerializeField] private AudioClip bossRun;

    //[SerializeField] private AudioClip lizardRun;


    private void PlayBossFire() {

    }

    private void PlayBossRoar() {

    }

    private void PlayBossRun() { 

    }

    private void PlayEnemyDeath() {
        enemyAudio.clip = enemyDeath;
        enemyAudio.Play();
    }

    private void PlayLizardRun() {

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
        EventController.Instance.OnPlayerDeath += PlayEspereDeath;
        EventController.Instance.OnEspereMeleeAttack += PlayEspereMeleeAttack;
        EventController.Instance.OnDoorClose += PlayDoorClose;
        EventController.Instance.OnEspereDash += PlayEspereDash;
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
        EventController.Instance.OnPlayerDeath -= PlayEspereDeath;
        EventController.Instance.OnEspereMeleeAttack -= PlayEspereMeleeAttack;
        EventController.Instance.OnDoorClose -= PlayDoorClose;
        EventController.Instance.OnEspereDash -= PlayEspereDash;

    }

    #endregion Methods
}