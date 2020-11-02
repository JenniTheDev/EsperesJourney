// Brought to you by Jenni

using System;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EventController {

    #region Singleton
   
    private static bool isQuitting = false;
    private static EventController instance = null;
    public static EventController Instance {
        get {
            if (instance == null && !isQuitting) {
                instance = new EventController();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    private EventController() { }
    #endregion

    #region EventSource & Delegates
    // Game events that require multiple game objects to update
    // should all be listed here
    public delegate void OnResetHandler();
    public event OnResetHandler OnReset;

    public delegate void OnPauseHandler();
    public event OnPauseHandler OnPause;

    public delegate void OnResumeHandler();
    public event OnResumeHandler OnResume;

    public delegate void OnGameOverHandler();
    public event OnGameOverHandler OnGameOver;

    public delegate void OnLivesLeftHandler();
    public event OnLivesLeftHandler OnLivesLeft;

    // Character Specific Events to possibly move in the future
    public delegate void OnHealthPotFindHandler();
    public event OnHealthPotFindHandler OnHealthPotFind;

    public delegate void OnPlayerDeathHandler();
    public event OnPlayerDeathHandler OnPlayerDeath;

    public delegate void OnTreasureFindHandler();
    public event OnTreasureFindHandler OnTreasureFind;

    public delegate void OnObjectDestroyHandler();
    public event OnObjectDestroyHandler OnObjectDestroy;

    



    #endregion

    #region Class Methods

    public void BroadcastReset() {
        OnReset?.Invoke();
    }

    public void BroadcastPause() {
        OnPause?.Invoke();
    }

    public void BroadcastResume() {
        OnResume?.Invoke();
    }

    public void BroadcastGameOver() {
        OnGameOver?.Invoke();
    }

    public void BroadcastLivesLeft() {
        OnLivesLeft?.Invoke();
    }

    public void BroadcastHealthPotFind() {
        OnHealthPotFind?.Invoke();
        Debug.Log("Broadcast");
    }

    public void BroadcastOnPlayerDeath() {
        OnPlayerDeath?.Invoke();
        Debug.Log("Broadcast death");
    }

    public void BroadcastOnTreasureFind() {
        OnTreasureFind?.Invoke();
        Debug.Log("Broadcast Treasure");
    }

    public void BroadcastOnObjectDestroy() {
        OnObjectDestroy?.Invoke();
        Debug.Log("Broadcast Object Destroy");
    }

    #endregion
}