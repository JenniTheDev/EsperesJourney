// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour, ITriggerable {

    // [SerializeField] private Key.KeyType keyType;

    // private DoorAnims doorAnims;

    

    private void Awake() {
        // doorAnims = GetComponent<DoorAnims>();

    }

   // public Key.KeyType GetKeyType() {
   //     return keyType;
   // }

     //TODO: Lock door on boss fight  
 

    public void OpenDoor() {
        // doorAnims.OpenDoor();
        
        // AudioSource doorMoveSound = GetComponent<AudioSource>();
        // doorMoveSound.Play();
        // Debug.Log("door move sound");
        gameObject.SetActive(false);
    }


    public void CloseDoor() {
        gameObject.SetActive(true);
        // doorAnim.PlayCloseAnim();
        // AudioSource doorMoveSound = GetComponent<AudioSource>();
        // doorMoveSound.Play();
        // Debug.Log("door move sound");
    }

    public void DoorFail() {
        // doorAnim.PlayOpenFailAnim();
        // AudioSource doorFailSound = GetComponent<AudioSource>();
        // doorFailSound.Play();
        // Debug.Log("door fail sound");
    }

    public void TriggerExecute() {
        OpenDoor();
    }

    public void TriggerRelease() {
        CloseDoor();
    }
}
