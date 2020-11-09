using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateKey : MonoBehaviour {

    [SerializeField] private GameObject door;
    // for only one key
     [SerializeField] private Key.KeyType keyType;
    // For a list of keys
    // [SerializeField] private List<Key.KeyType> keyList;
    private ITriggerable triggeredItem;

    private void Start() {
        triggeredItem = door.GetComponent<ITriggerable>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        KeyHolder keyHolder = collider.GetComponent<KeyHolder>();
        if (keyHolder != null && keyHolder.ContainsKey(keyType)) {
            triggeredItem.TriggerExecute();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        KeyHolder keyHolder = collider.GetComponent<KeyHolder>();
        if (keyHolder != null) {
            triggeredItem.TriggerRelease();
        }
 
    }
}
