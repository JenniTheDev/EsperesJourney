// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOperatedDoor : MonoBehaviour {
    [SerializeField] private List<Key> keysToOpen;
    // private DoorAnims doorAnims;

    private void Start() {
        Subscribe();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void Subscribe() {
        EventController.Instance.OnKeyHolderChange += CheckForKeyCombo;
    }

    private void OnDisable() {
        Unsubscribe();
    }

    private void Unsubscribe() {
        EventController.Instance.OnKeyHolderChange -= CheckForKeyCombo;
    }

    private void CheckForKeyCombo(List<KeyType> keys) {
        for (int i = 0; i < keysToOpen.Count && i < keys.Count; i++) {
            if (keys[i] != keysToOpen[i].Type) {
                EventController.Instance.BroadcastKeyComboFail();
                StartCoroutine(ResetKeyObjects());
                return;
            } else {
                EventController.Instance.BroadcastButtonPushSuccess();
            }
        }
        if (keys.Count == keysToOpen.Count) {
            OpenBridge();
        }
    }

    private void OpenBridge() {
        // doorAnims = GetComponent<DoorAnims>();
        // when door animation is done playing

        EventController.Instance.BroadcastBridgeOpen();
        gameObject.SetActive(false);
    }

    private IEnumerator ResetKeyObjects() {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < keysToOpen.Count; i++) {
            keysToOpen[i].gameObject.SetActive(true);
        }
    }
}