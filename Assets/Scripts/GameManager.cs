//brought to you by Jenni
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameState currentState = GameState.None;
   // [SerializeField] private GameObject startButton;
   // [SerializeField] private GameObject resumeButton;
    [SerializeField] private KeyCode quit;
    [SerializeField] private KeyCode pause;
    

    public GameState CurrentState {
        get { return this.currentState; }
        set { this.currentState = value; }
    }

    #region MonoBehaviour

    private void Start() {
        Subscribe();
        currentState = GameState.StartMenu;
    }

    private void Update() {
        if (currentState == GameState.Playing) {
            if (Input.GetKeyDown(pause)) {
                PauseGame();
            }
            if (Input.GetKeyDown(quit)) {
                    Application.Quit();
                }
        }
        if (currentState == GameState.Paused) {
            if (Input.GetKeyDown(pause)) {
                ResumeGame();
            }
        }
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }

    #endregion MonoBehaviour

    public void StartGame() {
        currentState = GameState.Playing;
       // startButton.SetActive(false);
       // resumeButton.SetActive(false);
        EventController.Instance.BroadcastReset();
    }

    public void PauseGame() {
        currentState = GameState.Paused;

        //  startButton.SetActive(true);
        //  resumeButton.SetActive(true);
        Time.timeScale = 0;
        
       // level1Music.Stop();
       //.enabled = false;
        print("We are pressing StartButton and Pausing game.");
    }

    

    public void ResumeGame() {
        currentState = GameState.Playing;
       // startButton.SetActive(false);
       // resumeButton.SetActive(false);
        EventController.Instance.BroadcastResume();
        
    }

    public void QuitGame() {
        currentState = GameState.Quit;
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }


    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnPause += PauseGame;
        EventController.Instance.OnReset += StartGame;
        EventController.Instance.OnResume += ResumeGame;
        
    }

    private void Unsubscribe() {
        EventController.Instance.OnPause -= PauseGame;
        EventController.Instance.OnReset -= StartGame;
        EventController.Instance.OnResume -= ResumeGame;
    }
}