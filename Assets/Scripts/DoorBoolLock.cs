// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBoolLock : MonoBehaviour, ITriggerable {

    // [SerializeField] private List<TriggerPlateNoKey> triggers;
    [SerializeField] private int numberOfSwitches;
     [SerializeField] private TriggerPlateNoKey triggerOne;
     [SerializeField] private TriggerPlateNoKey triggerTwo;
    [SerializeField] private AudioSource doorMotionSound;

    void Start() {
       

    }


    public void TriggerExecute() {
       if (PermissionCheck() == true) {
            doorMotionSound.Play();
            gameObject.SetActive(false);
        }
        
    }

    public void TriggerRelease() {
        // gameObject.SetActive(true);
    }

    public bool PermissionCheck() {
        //foreach (GameObject g in triggers) {
        //     g.GetComponent<GameObject>();
        //    if (g.IsTriggered() == false) {
        //        return false;
        //    } 
        //}
        if (triggerOne.IsTriggered() && triggerTwo.IsTriggered()) {
            return true;
        } else return false;
    }

    public void DoorMoveFail() {
        Debug.Log("Door Fail");
        // doorAnim.PlayOpenFailAnim();
        // AudioSource doorFailSound = GetComponent<AudioSource>();
        // doorFailSound.Play();
        // Debug.Log("door fail sound");
    }

}
