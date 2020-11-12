// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateNoKey : MonoBehaviour {
    [SerializeField] private GameObject door;
    // [SerializeField] private List<GameObject> doors;
    [SerializeField] private bool isTriggered;
    private ITriggerable triggeredItem;
    // [SerializeField] private GameObject triggerObject;


    private void Start() {
        triggeredItem = door.GetComponent<ITriggerable>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        // AudioSource buttonClick = GetComponent<AudioSource>();
        // buttonClick.Play();
        // Debug.Log("Button Click Sound");

        // compare layer   or other.gameObject.layer 
        // if (other.gameObject.layer == LayerMask.GetMask("Character")){}
        // anything on this layer to count
        // can set multiple layers to one object

        if (collider.gameObject.layer == LayerMask.NameToLayer("Player")) {
            isTriggered = true;
            Debug.Log("Is triggered" + isTriggered);
            // Commented out to try event system to open door
            triggeredItem.TriggerExecute();
            // Broadcast door trigger event ? 
            // EventController.Instance.BroadcastOnTriggerUse();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isTriggered = false;
        triggeredItem.TriggerRelease();
    }

    public bool IsTriggered() {
        return isTriggered;
    }


}
// Jenni's notes
// for plates, can use array
// check is this down all the way through
// have another object that subscribes to the events
// keep track of the plate number that fired
//  check order
// are the prievious ones good? 
// when one is wrong, switch them all back 
// indicator to let player know reset