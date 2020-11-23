// Jenni
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenOnlyDoor : MonoBehaviour, ITriggerable {
    // This script only removes the blocking colider. 
    // It is a one way door
    // should probably rename this
    [SerializeField] private bool doorStartPosition;
   // [SerializeField] private bool doorDidItsJob;
   // [SerializeField] private AudioClip doorMotionClip;
    [SerializeField] private AudioSource doorMotionSound;
    // private DoorAnims doorAnims;


    private void Awake() {
        // doorAnims = GetComponent<DoorAnims>();
        gameObject.SetActive(doorStartPosition);
        // doorDidItsJob = false;
        Subscribe();
    }
        
    public void OpenDoor() {
        // this is not working
      //  WaitASecond(2);
        // doorAnims.OpenDoor();
              
        doorMotionSound.Play();
        // EventController.Instance.BroadcastOnTriggerUse();
        // If using event manager to handle triggers, and you want to avoid triggering all doors every time
       
        // if doorDidItsJob is false, then 
        // doorDidItsJob = true;
        gameObject.SetActive(!doorStartPosition);
        
    }

   public void PlayOpenFailAnim() {
        // doorAnim.PlayOpenFailAnim();
        // AudioSource doorFailSound = GetComponent<AudioSource>();
        // doorFailSound.Play();
        // Debug.Log("door fail sound");
    }

   // public bool HasDoorMoved() {
       // return doorDidItsJob;
   // }

    public void TriggerExecute() {
        Debug.Log(" Trigger execute called");
        OpenDoor();
    }

    public void TriggerRelease() {
        
    }

    public void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnTriggerUse += TriggerExecute;
    }

    public void Unsubscribe() {
        EventController.Instance.OnTriggerUse -= TriggerExecute;

    }

    

    IEnumerator WaitASecond(float delay) {
        yield return new WaitForSecondsRealtime(delay);
        doorMotionSound.Play();
    }


}

