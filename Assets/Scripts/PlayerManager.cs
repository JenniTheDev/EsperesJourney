// Brought to you by Jenni
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    // 

    // Player statistics
    [SerializeField] private int playerHealth;
    [SerializeField] private int coinsCollected; // currency?
    [SerializeField] private int availableHealthPots;

    // TODO Player Sounds - Moved to SoundManager , but should they be left here??
    // [SerializeField] private AudioSource dashSound;
    // [SerializeField] private AudioSource attackSound;
    // [SerializeField] private AudioSource teleportSound;

    // Player game object  (not sure if this is right)
    [SerializeField] private GameObject player;

    #region Properties

    public int PlayerHealth {
        get { return playerHealth; }
        set { playerHealth = Math.Max(0, value); }
    }

   public int CoinsCollected {
        get { return coinsCollected; }
        set { coinsCollected = Math.Max(0, value); }
    }

    public int AvailableHealthPots {
        get { return availableHealthPots; }
        set { availableHealthPots = Math.Max(0, value); }
    }
    #endregion


    #region Monobehaviors
    // On awake?
    void Start() {
        Subscribe();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }
    #endregion


    #region Class Methods
    // not sure if these functions should be private or public
    // making them public for now so they can be used by other classes
    public void IncreaseHealth(int value) {
        // pass in value from pot or buff
        playerHealth =+ value;
        // Update UI Health Amount
    }

    public void DecreaseHealth(int value) {
        playerHealth =+ value;
        // Update UI Health Amount
    }

    public void CollectedCoins(int coinValue) {
        coinsCollected =+ coinValue;
        // Update UI coin amount
    }

    public void IncreaseHealthPotNum() {
        availableHealthPots++;
        // Update UI Health Pot amount
    }

    public void HealthPotUsed() {
        // TODO Health Pot Class with health pot values 
        IncreaseHealth(10);
    }



    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnHealthPotFind += IncreaseHealthPotNum;
    }

    private void Unsubscribe() {
        EventController.Instance.OnHealthPotFind -= IncreaseHealthPotNum;

    }

    #endregion

}
