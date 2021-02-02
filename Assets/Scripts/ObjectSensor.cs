// Digx7
// This script activates an event if it detected something in its collider or trigger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectSensor : MonoBehaviour {

    public enum mode { Collider, Trigger }

    [Header("Main")]
    [Tooltip("Collider: for if you have a generic 2D box collider attached.\nTrigger: for if you have the collider set as a trigger.")]
    [SerializeField] private mode sensorMode = mode.Collider;

    [Tooltip("Set this is you want to detect everything regardless of any tags.")]
    [SerializeField] private bool detectEverything = false;

    [SerializeField] private bool detectOnEnter = true;
    [SerializeField] private bool detectOnStay = false;
    [SerializeField] private bool detectOnExit = false;

    [SerializeField] private bool allowDuplicates = true;
    [SerializeField] private float timeBetweenDetectingDuplicates = 0.1f;

    [Tooltip("Set the tag of any objects this sensor is looking for.")]
    [SerializeField] private List<string> tagsToListenFor;

    [Space]
    [Header("Events")]
    [SerializeField] private UnityEvent detectedSomething;

    private Collision2D lastCollision2D;
    private Collider2D lastCollider2D;

    private void DetectedSomething(Collision2D col) {
      if(allowDuplicates) InvokeDetectedSomething();
      else{
        if(newCollision2D(col)) InvokeDetectedSomething();
      }
    }

    private void DetectedSomething(Collider2D col) {
      if(allowDuplicates) InvokeDetectedSomething();
      else{
        if(newCollider2D(col)) InvokeDetectedSomething();
      }
    }

    // --- Events ----------------------------------------------

    private void InvokeDetectedSomething() {
        detectedSomething.Invoke();
    }

    // --- Confermation Functions ------------------------------

    private bool isThisAnObjectToWatchFor_Collision(Collision2D col) {
        foreach (string _tag in tagsToListenFor) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    private bool isThisAnObjectToWatchFor_Collider(Collider2D col) {
        foreach (string _tag in tagsToListenFor) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    private bool newCollision2D(Collision2D col) {
      if(col == lastCollision2D) return false;
      else{
        setLastCollision2D(col);
        return true;
        }
    }

    private bool newCollider2D(Collider2D col) {
      if(col == lastCollider2D) return false;
      else{
        setLastCollider2D(col);
        return true;
        }
    }

    // --- Get variables -------------------------------------------

    public Collision2D getLastCollision2D() {
        return lastCollision2D;
    }

    public Collider2D getLastCollider2D() {
        return lastCollider2D;
    }

    public bool getDetectEverything() {
        return detectEverything;
    }

    private void setLastCollision2D(Collision2D input) {
      lastCollision2D = input;
      StartCoroutine(clearCollisionAndCollider());
    }

    private void setLastCollider2D(Collider2D input) {
      lastCollider2D = input;
      StartCoroutine(clearCollisionAndCollider());
    }

    private IEnumerator clearCollisionAndCollider(){
      yield return new WaitForSeconds(timeBetweenDetectingDuplicates);
      lastCollider2D = null;
      lastCollision2D = null;
      yield return null;
    }

    // --- Collisions --------------------------------------------

    // Enter ---
    public void OnCollisionEnter2D(Collision2D col) {
        if (sensorMode == mode.Collider && detectOnEnter && getDetectEverything() || isThisAnObjectToWatchFor_Collision(col))
          DetectedSomething(col);
    }

    // Triggers when the player collides with a trigger
    public void OnTriggerEnter2D(Collider2D col) {
        if (sensorMode == mode.Trigger && detectOnEnter && getDetectEverything() || isThisAnObjectToWatchFor_Collider(col))
            DetectedSomething(col);
    }

    // Stay ---
    public void OnCollisionStay2D(Collision2D col) {
        if (sensorMode == mode.Collider && detectOnStay && getDetectEverything() || isThisAnObjectToWatchFor_Collision(col))
            DetectedSomething(col);
    }

    // Triggers when the player collides with a trigger
    public void OnTriggerStay2D(Collider2D col) {
        if (sensorMode == mode.Trigger && detectOnStay && getDetectEverything() || isThisAnObjectToWatchFor_Collider(col))
            DetectedSomething(col);
    }

    // Exit ---
    public void OnCollisionExit2D(Collision2D col) {
        if (sensorMode == mode.Collider && detectOnExit && getDetectEverything() || isThisAnObjectToWatchFor_Collision(col))
            DetectedSomething(col);
    }

    // Triggers when the player collides with a trigger
    public void OnTriggerExit2D(Collider2D col) {
        if (sensorMode == mode.Trigger && detectOnExit && getDetectEverything() || isThisAnObjectToWatchFor_Collider(col))
            DetectedSomething(col);
    }
}
