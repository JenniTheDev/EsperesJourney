using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : MonoBehaviour {

    // This needs a correct value for health pot
    [SerializeField] private int amountOfCoins;
    [SerializeField] private GameObject coins;


    #region Properties
    public int numberofCoins {
        get { return amountOfCoins; }
        set { amountOfCoins = value; }
    }

    #endregion

    #region Monobehaviors
    // On awake?
    void Start() {

        coins = GetComponent<GameObject>();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }
    #endregion


    #region Methods
    public void Subscribe() {
        EventController.Instance.OnTreasureFind += FoundATreasure;

    }

    public void Unsubscribe() {
        EventController.Instance.OnTreasureFind -= FoundATreasure;
    }

    private void FoundATreasure() {
        AudioSource treasurePickup = GetComponent<AudioSource>();
        treasurePickup.Play();
        Debug.Log("treasure sound");
    }
    #endregion
}
