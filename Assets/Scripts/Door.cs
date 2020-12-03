// Vast & Jenni
using System;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

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

    protected virtual void OpenDoor() {
    }

    public virtual void ResetTriggers() {
        foreach (Trigger t in triggers) {
            t.ResetTrigger();
        }
        triggeredOrder = new List<int>();
    }

    private void UpdateTriggers(Trigger trigger) {
        triggeredOrder.Add(Array.IndexOf(triggers, trigger));
        if (forceOrder && !TriggeredInOrder()) { ResetTriggers(); }
        CheckDoorLock();
    }

    private void CheckDoorLock() {
        if (AllTriggered()) {
            OpenDoor();
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
}