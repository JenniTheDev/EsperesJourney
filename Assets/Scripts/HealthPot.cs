using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour {

    // This needs a correct value for health pot
    [SerializeField] private int healthPotStrength = 50;
    [SerializeField] private GameObject healthPotObject;

    #region Properties
    public int HealthPotAmount {
        get { return healthPotStrength; }
        set { healthPotStrength = value; }
    }

    #endregion

    #region Monobehaviors
    // On awake?
    void Start() {

        healthPotObject = GetComponent<GameObject>();
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
        EventController.Instance.OnHealthPotFind += PlayHealthPotPickup;

    }

    public void Unsubscribe() {
        EventController.Instance.OnHealthPotFind -= PlayHealthPotPickup;
    }

    private void PlayHealthPotPickup() {
        AudioSource healthPotPickup = GetComponent<AudioSource>();
        healthPotPickup.Play();
        Debug.Log("sound");
    }
    #endregion
}
