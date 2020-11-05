// brought to you by Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    // The key list will need to be shown on the UI if this is used

    [SerializeField] private List<Key.KeyType> keyList;

    private void Awake() {
        keyList = new List<Key.KeyType>();
        Subscribe();
    }

    public List<Key.KeyType> GetKeyList() {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType) {
        Debug.Log("Added Key:" + keyType);
            keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType) {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType) {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Key key = collider.GetComponent<Key>();
        // Debug.Log("Collided with Key");
        if (key != null) {
            // Add key to list
            AddKey(key.GetKeyType());
            // destroy key object
            Destroy(key.gameObject);
            // Play key pickup sound?
            // broadcast key pickup ? 
        }
        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
           if (keyDoor != null) {
            // if holding the right key to the door
            if (ContainsKey(keyDoor.GetKeyType())) {
                keyDoor.OpenDoor();
                // Remove Key if single use key
                RemoveKey(keyDoor.GetKeyType());
                
            } else {
                // play fail sound for key?
                // fail door animation ?
            }
        } 
    }

    // For event manager
    public void Subscribe() {
        Unsubscribe();
        // event for key use ? 
        
    }

    public void Unsubscribe() {

    }


}
