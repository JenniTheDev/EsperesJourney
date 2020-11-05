// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnlyDoor : MonoBehaviour, ITriggerable {
    // This script only removes the blocking colider. 
    // It is opening a route only

    // private DoorAnims doorAnims;

    private void Awake() {
        // doorAnims = GetComponent<DoorAnims>();
    }
        
    public void OpenDoor() {
        // doorAnims.OpenDoor();
        // sets door inactive when key is used - could also destroy object ? 
        // Play door sound
        gameObject.SetActive(false);
    }

   public void PlayOpenFailAnim() {
        // doorAnim.PlayOpenFailAnim();
        // AudioSource doorFailSound = GetComponent<AudioSource>();
        // doorFailSound.Play();
        // Debug.Log("door fail sound");
    }

    public void TriggerExecute() {
        OpenDoor();
    }

    public void TriggerRelease() {
        
    }
}

