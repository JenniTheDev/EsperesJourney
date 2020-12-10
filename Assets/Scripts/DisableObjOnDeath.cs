using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjOnDeath : MonoBehaviour {

    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private GameObject onThisObjDeath;

    void Start() {
        Subscribe();
       // objectToDestroy = GetComponent<GameObject>();
    }

    void Update() {
        if (onThisObjDeath == null) {
            objectToDestroy.SetActive(false);
            EventController.Instance.BroadcastDoorOpen();
        }
    }
    private void DisableObject() {
        // animation 
        
        if (onThisObjDeath.activeSelf == false) {
            objectToDestroy.SetActive(false);
        }



    }


    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnEnemyDeath += DisableObject;
    }

   
    private void Unsubscribe() {
        EventController.Instance.OnEnemyDeath -= DisableObject;
    }


}
