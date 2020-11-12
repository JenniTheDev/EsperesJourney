using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateKey : MonoBehaviour {

    [SerializeField] private GameObject door;
    // for only one key
    // [SerializeField] private Key.KeyType keyType;
    // For a list of keys
     [SerializeField] private List<Key.KeyType> keyList;
    [SerializeField] private List<Key.KeyType> playerKeyList;
    private ITriggerable triggeredItem;
    [SerializeField] private int numOfCorrectKeys = 0;
    [SerializeField] private int numCorrectExpected; 

    private void Start() {
        triggeredItem = door.GetComponent<ITriggerable>();
        numCorrectExpected = keyList.Count;
    }

    // when keys collected = num of expected keys, check lists and trigger door
    // may avoid having to specifically hit trigger
    // if lists dont match, clear player key list, play fail sound


    private void OnTriggerEnter2D(Collider2D collider) {
        KeyHolder keyHolder = collider.GetComponent<KeyHolder>();
        playerKeyList = keyHolder.GetKeyList();
        if (keyHolder != null) {
            for (int i = 0; i < playerKeyList.Count; i++) {
                if (playerKeyList[i] == keyList[i]) {
                    numOfCorrectKeys++;
                }
            }
        }
        if (numOfCorrectKeys == numCorrectExpected) {
            keyHolder.ResetKeyList();
            triggeredItem.TriggerExecute();
            numOfCorrectKeys = 0;
            gameObject.SetActive(false);
        } else {
            // play audio for fail 

            // fail animation ? 
            // If Keys are being used and the key objects are being destroyed, respawn key objects here
            keyHolder.ResetKeyList();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        KeyHolder keyHolder = collider.GetComponent<KeyHolder>();
        if (keyHolder != null) {
            triggeredItem.TriggerRelease();
        }
 
    }
}
