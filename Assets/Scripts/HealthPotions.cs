// Reeder ?
using UnityEngine;
using UnityEngine.UI;

public class HealthPotions : MonoBehaviour {
    public Image[] potions;
    public Sprite potion;

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }

    //UpdateCounter is called when OnHealthPotsUpdate is broadcasted
    private void UpdateCounter(int numOfPotions, int maxPotions) {
        //do something about max health potions; currently uses maxpotions var but not hooked up to actual image array size; locked at 3
        for (int i = 0; i < maxPotions; i++) {
            if (i < numOfPotions) {
                potions[i].enabled = true;
            } else {
                potions[i].enabled = false;
            }
        }
    }

    public void Subscribe() {
        Unsubscribe();
        // EventController.Instance.OnHealthPotFind += UpdateCounter;
    }

    public void Unsubscribe() {
        //  EventController.Instance.OnHealthPotFind -= UpdateCounter;
    }
}