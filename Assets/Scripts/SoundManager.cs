// Brought to you by Jenni
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [Header("Audio Sources")]
    [SerializeField] public AudioSource soundtrack;
    [SerializeField] public AudioSource environmentalSFX;
    [SerializeField] public AudioSource espereAudio;
    [SerializeField] public AudioSource enemyAudio;
    [SerializeField] public AudioSource miscAudio;

    #region Soundtracks
    [Header ("Soundtracks")]
    [SerializeField] private AudioClip sewerLevelMusicSound;
    [SerializeField] private AudioClip pauseMusicSound;
    [SerializeField] private AudioClip gameWonSound;
    [SerializeField] private AudioClip sewerAmbiant;
    [SerializeField] private AudioClip mainMenuMusic;

    #endregion

    #region Espere
    [Header("Espere's SFX")]
    [SerializeField] private AudioClip playerDeathSound;
    [SerializeField] private AudioClip dashSound;
    [SerializeField] private AudioClip meleeAttackSound;
    [SerializeField] private AudioClip takingDamage;
    [SerializeField] private AudioClip runningSound;
    // [SerializeField] private AudioClip rangedAttackSound;
    // [SerializeField] private AudioClip healthPotPickup;
    //  [SerializeField] private AudioClip teleportSound;


    #endregion

    #region Enemies
    [Header("Enemy SFX")]
    [SerializeField] private AudioClip bossFire;
    [SerializeField] private AudioClip bossRoar;
    [SerializeField] private AudioClip bossRun;
    [SerializeField] private AudioClip enemyDeath;
    [SerializeField] private AudioClip lizardRun;


    #endregion

    #region Environmental SFX  
    [Header("Environmental SFX")]
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;
    // don't put door fail and door click on the same audio source
    [SerializeField] private AudioClip doorButtonClick;
    [SerializeField] private AudioClip propBreakGlassOrCeramic;
    [SerializeField] private AudioClip propBreakMisc;
    [SerializeField] private AudioClip propBreakWood;
    [SerializeField] private AudioClip doorFail;
    [SerializeField] private AudioClip bridgeOpen;



    #endregion

    #region Misc
   

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
        miscAudio.clip = pauseMusicSound;
        miscAudio.Play();
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

    private void PlayEspereRun() {
        espereAudio.clip = runningSound;
        espereAudio.Play();
    }

    private void PlayEspereDamageTaken() {
        espereAudio.clip = takingDamage;
        espereAudio.Play();
    }

    private void PlayBossFire() {
        enemyAudio.clip = bossFire;
        enemyAudio.Play();
    }

    public void PlayBossRoar() {
        enemyAudio.clip = bossRoar;
        enemyAudio.Play();
    }

    public void PlayBossRun() {
        enemyAudio.clip = bossRun;
        enemyAudio.Play();
    }

    public void PlayLizardRun() {
        enemyAudio.clip = lizardRun;
        enemyAudio.Play();
    }

    private void PlayEnemyDeath() {
        enemyAudio.clip = enemyDeath;
        enemyAudio.Play();
    }
         

    private void PauseAllAudio() {
        soundtrack.Pause();
        environmentalSFX.Pause();
        espereAudio.Pause();
        enemyAudio.Pause();
        // miscAudio.Pause();
        PlayPauseMusic();

    }

    private void ResumeAllAudio() {
        miscAudio.Stop();
        soundtrack.UnPause();
        environmentalSFX.UnPause();
        espereAudio.UnPause();
        enemyAudio.UnPause();
        // miscAudio.UnPause();
        
    }


    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnReset += PlayLevelMusic;
        EventController.Instance.OnResume += ResumeAllAudio;
        EventController.Instance.OnPause += PauseAllAudio;
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
        EventController.Instance.OnEspereRun += PlayEspereRun;
        EventController.Instance.OnEnemyDeath += PlayEnemyDeath;
        EventController.Instance.OnBossFire += PlayBossFire;
    }

    private void Unsubscribe() {
        EventController.Instance.OnReset -= PlayLevelMusic;
        EventController.Instance.OnResume -= ResumeAllAudio;
        EventController.Instance.OnPause -= PauseAllAudio;
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
        EventController.Instance.OnEspereRun -= PlayEspereRun;
        EventController.Instance.OnEnemyDeath -= PlayEnemyDeath;
        EventController.Instance.OnBossFire -= PlayBossFire;

    }

    #endregion Methods
}