using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectSensor : MonoBehaviour
{

  public enum mode {Collider, Trigger}
  [SerializeField]private mode sensorMode = mode.Collider;
  [SerializeField]private bool detectEverything = false;
  [SerializeField]private List<string> tagsToListenFor;
  [Space]

  [Header("Events")]
  [SerializeField]private UnityEvent detectedSomething;

  private Collision2D lastCollision2D;
  private Collider2D lastCollider2D;

  // --- Events ----------------------------------------------

  public void InvokeDetectedSomething(){
    detectedSomething.Invoke();
  }

  // --- Confermation Functions ------------------------------

  public bool isThisAnObjectToWatchFor_Collision (Collision2D col){
    foreach(string _tag in tagsToListenFor)
    {
      if(col.gameObject.tag == _tag) return true;
    }
    return false;
  }

  public bool isThisAnObjectToWatchFor_Collider (Collider2D col){
    foreach(string _tag in tagsToListenFor)
    {
      if(col.gameObject.tag == _tag) return true;
    }
    return false;
  }

  // --- Get variables -------------------------------------------

  public Collision2D getLastCollision2D(){
    return lastCollision2D;
  }

  public Collider2D getLastCollider2D(){
    return lastCollider2D;
  }

  public bool getDetectEverything(){
    return detectEverything;
  }

  // --- Collisions --------------------------------------------

  public void OnCollisionEnter2D (Collision2D col){
      Debug.Log ("Object touched something");

      if(getDetectEverything() || isThisAnObjectToWatchFor_Collision(col))
        InvokeDetectedSomething();
  }

  // Triggers when the player collides with a trigger
  public void OnTriggerEnter2D (Collider2D col){
      Debug.Log ("Object touched something");

      if(getDetectEverything() || isThisAnObjectToWatchFor_Collider(col))
        InvokeDetectedSomething();
  }
}
