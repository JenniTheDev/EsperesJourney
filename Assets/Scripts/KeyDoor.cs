﻿// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;

    // private DoorAnims doorAnims;

    private void Awake() {
        // doorAnims = GetComponent<DoorAnims>();
    }

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    //private void OnTriggerEnter2D(Collider2D collider) {
    //    KeyHolder keyHolder = collider.GetComponent<KeyHolder>();
    //    if (keyHolder != null) {
    //        if (keyHolder.ContainsKey(keyType)) {
    //            OpenDoor();
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collider) {
         KeyHolder keyHolder = collider.GetComponent<KeyHolder>();
         if (keyHolder != null) {
              CloseDoor();
          }

        
    }

    public void OpenDoor() {

        //  doorAnims.OpenDoor();
        // sets door inactive when key is used - could also destroy object ? 
        // Play door sound
        gameObject.SetActive(false);

    }


    public void CloseDoor() {
        gameObject.SetActive(true);
        // doorAnim.PlayCloseAnim();
        // play door closed sound
    }

    public void PlayOpenFailAnim() {
        // doorAnim.PlayOpenFailAnim();
        // AudioSource doorFailSound = GetComponent<AudioSource>();
        // doorFailSound.Play();
        // Debug.Log("door fail sound");
    }
}
