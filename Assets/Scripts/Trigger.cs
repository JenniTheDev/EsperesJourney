using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour {
    [SerializeField]
    private bool isTriggered;
    [SerializeField]
    private Collider2D[] canTripColliders;

    public bool IsTriggered {
        get { return this.isTriggered; }
    }

    public event Action<Trigger> OnTriggered;
    public event Action<Trigger> OnTriggerChanged;

    #region MonoBehaviour
    private void Start() {
        if(this.canTripColliders == null || this.canTripColliders.Length < 1) {
            Debug.Log($"FYI: Trigger {gameObject.name} has no colliders set");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(!this.isTriggered && CanTrip(collision)) {
            FireTrigger();
        }
    }

    #endregion
    private bool CanTrip(Collider2D collision) {
        foreach(Collider2D col in canTripColliders) {
            if(col == collision) { return true; }
        }
        return false;
    }

    private void FireTrigger() {
        bool hasChanged = IsTriggered == false;
        this.isTriggered = true;
        OnTriggered?.Invoke(this);
        if(hasChanged) { OnTriggerChanged?.Invoke(this); }
    }

    public void ResetTrigger() {
        this.isTriggered = false;
    }
}