using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyDoorOpen : MonoBehaviour {

    [SerializeField] private GameObject doorToOpen;
    [SerializeField] private GameObject trigger;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            doorToOpen.SetActive(false);
        }
    }
}
