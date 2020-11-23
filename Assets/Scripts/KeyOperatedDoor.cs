using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOperatedDoor : MonoBehaviour {
    [SerializeField] private List<Key> keysToOpen;

    void Start() {
        EventController.Instance.OnKeyHolderChange += CheckForKeyCombo;
    }

    private void CheckForKeyCombo(List<KeyType> keys) {
        if(HasKeys(keys)) {
            // Open Door
            // Erase Key Holder
        } else {

        }
    }

    private bool HasKeys(List<KeyType> keys) {
        for(int i = 0; i < keysToOpen.Count; i++) {
            if(keys[i] != keysToOpen[i].Type) {
                return false;
            }
        }
        return true;
    }
}
