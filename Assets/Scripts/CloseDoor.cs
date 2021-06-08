// Jenni
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class CloseDoor : MonoBehaviour {
    [SerializeField] private bool doorStartPosition;
    private float delay = 0.5f;
    [SerializeField] private Animator doorAnims;

    private void Awake() {
        gameObject.SetActive(doorStartPosition);
    }

   

    [SerializeField]
    private bool forceOrder;

    [SerializeField]
    private bool resetOnOrderFail;

    [SerializeField]
    private Trigger[] triggers;

    
    private List<int> triggeredOrder;

    #region MonoBehaviour

    private void Start() {
        if (triggers == null) { triggers = new Trigger[0]; }
        ResetTriggers();
        foreach (Trigger t in triggers) {
            t.OnTriggered += UpdateTriggers;
        }

    }

    #endregion MonoBehaviour

    

    public virtual void ResetTriggers() {
        foreach (Trigger t in triggers) {
            t.ResetTrigger();
        }
        triggeredOrder = new List<int>();
    }

    private void UpdateTriggers(Trigger trigger) {
        triggeredOrder.Add(Array.IndexOf(triggers, trigger));
        if (forceOrder && !TriggeredInOrder()) {
            EventController.Instance.BroadcastKeyComboFail();
            ResetTriggers();
        }
        CheckDoorLock();
    }

    private void CheckDoorLock() {
        if (AllTriggered()) {
            CloseTheDoor();
        }
    }

    private bool AllTriggered() {
        bool result = triggers.Length > 0;
        foreach (Trigger t in triggers) {
            if (!t.IsTriggered) { return false; }
        }
        return result;
    }

    private bool TriggeredInOrder() {
        bool result = false;
        for (int i = 0; i < triggeredOrder.Count; i++) {
            result = triggeredOrder[i] == i;
            if (result) { continue; } else { return false; }
        }
        return result;
    }

    private void CloseTheDoor() {
        doorAnims.SetTrigger("DoorOpen");  // calls variable in the animation parameters
        StartCoroutine(CloseAfterAnimation());
    }

    private IEnumerator CloseAfterAnimation() {
        // WaitForEndOfFrame pause = new WaitForEndOfFrame();

        // while (doorAnimation.GetCurrentAnimatorStateInfo(0).IsName("2 Tile Door Open")) {
        //     yield return pause;
        //  }

        yield return new WaitForSeconds(delay);

        EventController.Instance.BroadcastOnDoorClose();
        gameObject.SetActive(true);
    }
}