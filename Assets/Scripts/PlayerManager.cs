using System;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    // Player statistics
    [SerializeField] private int playerHealth;
    [SerializeField] private int livesLeft;
    [SerializeField] private int coinsCollected; // currency?
    [SerializeField] private int availableHealthPots;
    [SerializeField] private int MAXHPOTS = 3;

    // Player Sounds
    [SerializeField] private AudioSource dashSound;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource teleportSound;

    // Player game object  (not sure if this is right)
    [SerializeField] private GameObject player;

    #region Properties

    public int PlayerHealth {
        get { return playerHealth; }
        set { playerHealth = Math.Max(0, value); }
    }

    public int LivesLeft {
        get { return livesLeft; }
        set { livesLeft = Math.Max(0, value); }
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

    void Start() {

    }

    #endregion


    #region Class Methods
    // not sure if these functions should be private or public
    // making them public for now so they can be used by other classes
    public void IncreaseHealth(int value) {
        // pass in value from pot or buff
        playerHealth += value;

        // Update UI Health Amount
        EventController.Instance.BroadcastHealthUpdate(playerHealth);
    }

    public void DecreaseHealth(int value) {
        playerHealth += value;

        // Update UI Health Amount
        EventController.Instance.BroadcastHealthUpdate(playerHealth);
    }

    public void CollectedCoins(int coinValue) {
        coinsCollected += coinValue;
        // Update UI coin amount with total coins collected
        EventController.Instance.BroadcastCoinUpdate(coinsCollected);
    }

    public void HealthPotsOnEnable()
    {
        if ((availableHealthPots + 1) <= MAXHPOTS)
        {
            availableHealthPots += 1;
            //Update UI health pots
            EventController.Instance.BroadcastHealthPotsUpdate(availableHealthPots, MAXHPOTS);
        }
    }

    public void HealthPotsOnDisable()
    {
        if ((availableHealthPots - 1) >= 0)
        {
            availableHealthPots -= 1;
            //broadcast event
            EventController.Instance.BroadcastHealthPotsUpdate(availableHealthPots, MAXHPOTS);
        }
    }
    // TODO LivesLeft, health pots OnEnable, OnDisable, Subscribe and Unsubscribe








    #endregion

}
