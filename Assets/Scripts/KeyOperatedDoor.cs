using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOperatedDoor : MonoBehaviour {
    [SerializeField] private List<Key> keysToOpen;
    [SerializeField] private AudioSource doorMotionSound;
    // private DoorAnims doorAnims;

    void Start() {
        EventController.Instance.OnKeyHolderChange += CheckForKeyCombo;
    }

    // TODO: Pickup keys when stepped on
    //TODO: Reset keys on fail
    

    private void CheckForKeyCombo(List<KeyType> keys) {
        for (int i = 0; i < keysToOpen.Count && i < keys.Count; i++) {
            if (keys[i] != keysToOpen[i].Type) {
                EventController.Instance.BroadcastKeyComboFail();
                return;  // this works
                //  make it unable to pick up the same key twice -  decative the key
            }
        }
        if (keys.Count == keysToOpen.Count) { // not only are they the same type, they are the same count
            OpenBridge();
        }
    }

    private void OpenBridge() {
        // doorAnims = GetComponent<DoorAnims>();
        //when door animation is done playing
        doorMotionSound.Play();
        gameObject.SetActive(false);

    }
}
