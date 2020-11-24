// brought to you by Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour {

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
        keyList.Add(keyType);
        Debug.Log($"Added Key: {keyType} {keyList.Count}");
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
        if (key != null) {
            Debug.Log($"{key.Type} {collider.gameObject.name}");
            AddKey(key.Type);
            EventController.Instance.BroadcastKeyHolderChange(keyList);
            collider.gameObject.SetActive(false);
        }
    }

    public void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnKeyComboFail += ResetKeyList;
        EventController.Instance.OnDoorOpen += ResetKeyList;
        EventController.Instance.OnBridgeOpen += ResetKeyList;

    }

    public void Unsubscribe() {
        EventController.Instance.OnKeyComboFail -= ResetKeyList;
        EventController.Instance.OnDoorOpen -= ResetKeyList;
        EventController.Instance.OnBridgeOpen += ResetKeyList;

    }
}
