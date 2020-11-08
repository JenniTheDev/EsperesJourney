// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateNoKey : MonoBehaviour
{
     [SerializeField] private GameObject door;
   // [SerializeField] private List<GameObject> doors;

    private ITriggerable triggeredItem;

    private void Start() {
        triggeredItem = door.GetComponent<ITriggerable>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        // AudioSource buttonClick = GetComponent<AudioSource>();
        // buttonClick.Play();
        // Debug.Log("Button Click Sound");
        triggeredItem.TriggerExecute();
        
    }

    private void OnTriggerExit2D(Collider2D collider) {

            triggeredItem.TriggerRelease();
        

    }
}
