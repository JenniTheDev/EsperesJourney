// brought to you by Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour {
    // The key can be shown on the UI if we want
    // Or we can just leave them in the list
    // They can be single use or used until a point when the list is cleared

    [SerializeField] private List<KeyType> keyList;

    #region MonoBehaviour
    private void Awake() {
        keyList = new List<KeyType>();
    }

    private void Start() {
        Subscribe();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }
    #endregion

    public List<KeyType> GetKeyList() {
        return keyList;
    }

    public void AddKey(KeyType keyType) {
        Debug.Log("Added Key:" + keyType);
        // AudioSource sucessPickup = GetComponent<AudioSource>();
        // sucessPickup.Play();
        // Debug.Log("Sucessful Key Pickup");
        keyList.Add(keyType);
    }

    public void RemoveKey(KeyType keyType) {
        keyList.Remove(keyType);
    }

    public void ResetKeyList() {
        keyList.Clear();
    }

    public bool ContainsKey(KeyType keyType) {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Key key = collider.GetComponent<Key>();
        // Debug.Log("Collided with Key");
        if (key != null) {
            // Add key to list
            AddKey(key.Type);
            // Play sucessful action sound 
            EventController.Instance.BroadcastKeyHolderChange(keyList);


            // destroy key object
            // Not destroying key object since keys are not being physical keys for now
            // Destroy(key.gameObject);
            // Play key pickup sound?
            // broadcast key pickup ? 
        }
        //    KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        //       if (keyDoor != null) {
        //        // if holding the right key to the door
        //        if (ContainsKey(keyDoor.GetKeyType())) {
        //            keyDoor.OpenDoor();
        //            // Remove Key if single use key
        //           // RemoveKey(keyDoor.GetKeyType());

        //        } else {
        //            // play fail sound for key?
        //            // fail door animation ?
        //        }
        //    } 
    }

    // For event manager
    public void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnKeyComboFail += ResetKeyList;
    }

    public void Unsubscribe() {
        EventController.Instance.OnKeyComboFail -= ResetKeyList;
    }
}
