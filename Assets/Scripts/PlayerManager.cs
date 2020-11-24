// Jenni
using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    // Player statistics
    [SerializeField] private int playerHealth;

    [SerializeField] private int coinsCollected; // currency?
    [SerializeField] private int availableHealthPots;
    [SerializeField] private int MAXHPOTS = 3;

    // Player Sounds
    [SerializeField] private AudioSource dashSound;

    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource teleportSound;

    // Player game object  (not sure if this is right)
    [SerializeField] private GameObject player;

    private Rigidbody2D character;
    private LayerMask wallMask;
    private LayerMask healthPotMask;
    private LayerMask treasureChestMask;

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

    #endregion Properties

    #region Monobehaviors

    private void Start() {
        Subscribe();
        character = GetComponent<Rigidbody2D>();
        wallMask = LayerMask.NameToLayer("Wall");
        healthPotMask = LayerMask.NameToLayer("HealthPot");
        treasureChestMask = LayerMask.NameToLayer("Treasure");
    }

    #endregion Monobehaviors

    #region Class Methods

    // not sure if these functions should be private or public
    // making them public for now so they can be used by other classes
    public void IncreaseHealth(int value) {
        // pass in value from pot or buff
        playerHealth += value;

        // Update UI Health Amount
        // EventController.Instance.BroadcastHealthUpdate(playerHealth);
    }

    public void DecreaseHealth(int value) {
        playerHealth += value;

        // Update UI Health Amount
        // EventController.Instance.BroadcastHealthUpdate(playerHealth);
    }

    public void CollectedCoins(int coinValue) {
        coinsCollected += coinValue;
        // Update UI coin amount with total coins collected
        // EventController.Instance.BroadcastCoinUpdate(coinsCollected);
    }

    // TODO LivesLeft, health pots OnEnable, OnDisable, Subscribe and Unsubscribe
    public void HealthPotsOnEnable() {
        if ((availableHealthPots + 1) <= MAXHPOTS) {
            availableHealthPots += 1;
            //Update UI health pots
            // EventController.Instance.BroadcastHealthPotsUpdate(availableHealthPots, MAXHPOTS);
        }
    }

    public void HealthPotsOnDisable() {
        if ((availableHealthPots - 1) >= 0) {
            availableHealthPots -= 1;
            //broadcast event
            // EventController.Instance.BroadcastHealthPotsUpdate(availableHealthPots, MAXHPOTS);
        }
    }

    // TODO LivesLeft, health pots OnEnable, OnDisable, Subscribe and Unsubscribe

    public void HealthPotUsed() {
        // TODO Health Pot Class with health pot values
        // This number should not be hardcoded
        IncreaseHealth(10);
    }

    public void PlayerDied() {
        // do death reset here
    }

    // Added these
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == wallMask) {
            // This doesn't stop the player from going through the wall
            character.velocity = Vector2.zero;
        }

        // TODO This is not working, does not say player touched the health pot, what did I do wrong?
        if (collision.gameObject.layer == healthPotMask) {
            Debug.Log("Health Pot Hit");
            EventController.Instance.BroadcastHealthPotFind();
        }

        if (collision.gameObject.layer == treasureChestMask) {
            Debug.Log("Treasure Hit");
            EventController.Instance.BroadcastOnTreasureFind();
        }
    }

    private void Subscribe() {
        Unsubscribe();
        //  EventController.Instance.OnHealthPotFind += IncreaseHealthPotNum;
        EventController.Instance.OnPlayerDeath += PlayerDied;
    }

    private void Unsubscribe() {
        //  EventController.Instance.OnHealthPotFind -= IncreaseHealthPotNum;
        EventController.Instance.OnPlayerDeath -= PlayerDied;
    }

    #endregion Class Methods
}