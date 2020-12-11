using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjOnDeath : MonoBehaviour {

    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private GameObject onThisObjDeath;
    private bool ignoreThis = false;

    void Start() {
       
       
    }

    void Update() {
      
            if (onThisObjDeath == null) {
                objectToDestroy.SetActive(false);
                         
            }
      
    }
   
    private void PlayDoorOpen() {
        EventController.Instance.BroadcastDoorOpen();
    }



}
