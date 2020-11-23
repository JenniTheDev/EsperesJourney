using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSuccessTrigger : MonoBehaviour {

    [SerializeField] private GameObject door;
    // [SerializeField] private List<GameObject> doors;
    // for only one key
    // [SerializeField] private Key.KeyType keyType;
    // For a list of keys
    [SerializeField] private List<Key.KeyType> keyList;
    [SerializeField] private List<Key.KeyType> playerKeyList;
    private ITriggerable triggeredItem;
    [SerializeField] private int numOfCorrectKeys = 0;
    [SerializeField] private int numCorrectExpected;
    [SerializeField] private AudioSource doorFailSound;
    [SerializeField] private GameObject player;

    void Start() {
        triggeredItem = door.GetComponent<ITriggerable>();
        numCorrectExpected = keyList.Count;
       
    }

    // Update is called once per frame
    void Update() {
        KeyHolder keyHolder = player.GetComponent<KeyHolder>();
        playerKeyList = keyHolder.GetKeyList();
        if (keyHolder != null && playerKeyList.Count <= numCorrectExpected) {
            for (int i = 0; i < playerKeyList.Count; i++) {
                if (playerKeyList[i] == keyList[i]) {
                    numOfCorrectKeys++;
                }
            }
        }
        // if correct
        if (numOfCorrectKeys == numCorrectExpected) {
            keyHolder.ResetKeyList();
            triggeredItem.TriggerExecute();
            numOfCorrectKeys = 0;
            gameObject.SetActive(false);
            // if not correct
        } else if (playerKeyList.Count >= numCorrectExpected || (playerKeyList.Count == numCorrectExpected && numOfCorrectKeys < numCorrectExpected)) {
            doorFailSound.Play();
            keyHolder.ResetKeyList();
            numOfCorrectKeys = 0;
        }




        // If Keys are being used and the key objects are being destroyed, respawn key objects here
        // keyHolder.ResetKeyList();
        //}

        // This crashes Unity
        //    while (playerKeyList.Count < 5) {
        //        for (int i = 0; i < playerKeyList.Count; i++) {
        //            if (playerKeyList[i] == keyList[i]) {
        //                numOfCorrectKeys++;
        //            }
        //        }
        //        if (numOfCorrectKeys == numCorrectExpected) {
        //            keyHolder.ResetKeyList();
        //            triggeredItem.TriggerExecute();
        //            numOfCorrectKeys = 0;
        //            gameObject.SetActive(false);
        //        } else if (playerKeyList.Count > numCorrectExpected) {
        //            doorFailSound.Play();
        //            keyHolder.ResetKeyList();
        //            numOfCorrectKeys = 0;
        //        }

        //    }



    }
}

