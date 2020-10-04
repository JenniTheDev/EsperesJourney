using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour
{
  [Header ("Health")]
    [Tooltip ("This is the objects current health")]
    [SerializeField] int currentHealth = 100;
    [Tooltip ("This is the objects players health")]
    [SerializeField] int maxHealth = 100;
    [Tooltip ("This is the objects players health.  If the current health ever equals this the player will die")]
    [SerializeField] int minHealth = 0;
    [Tooltip ("List all the GameObject tags of objects that can alter the health of this gameObject")]
    [SerializeField] private List<string> tagsThatCanAffectObjectsHealth;
    [SerializeField] private float playerDeathTimeLength = 0.1f; // The Length in time unitl this gameObject is destroyed

  [Header ("Events")]
    [SerializeField] private  UnityEvent healthIncrease;
    [SerializeField] private  UnityEvent healthDecrease;
    [SerializeField] private  UnityEvent objectDeath;

  // --- Main ------------------------------------------------------

  // Sets the currentHealth to the given input
  public void setCurrentHealth(int input){
      currentHealth = input;
      Debug.Log ("The objects currentHealth was set to " + input);
  }

  public bool canThisObjectDamageMe (Collision2D col){
    foreach(string _tag in tagsThatCanAffectObjectsHealth)
    {
      if(col.gameObject.tag == _tag) return true;
    }
    return false;
  }

  public bool canThisObjectDamageMe_Collider2D (Collider2D col){
    foreach(string _tag in tagsThatCanAffectObjectsHealth)
    {
      if(col.gameObject.tag == _tag) return true;
    }
    return false;
  }

  // Adds the given input to the currentHealth
  public void updateCurrentHealth(int input){
      currentHealth += input;
      Debug.Log ("Something changed the objects currentHealth by " + input + " units");

      if (input > 0) healthIncrease.Invoke();
      if (input < 0) healthDecrease.Invoke();
  }

  // Returns true if the currentHealth is less than or equal to the minHealth
  public bool isObjectDead(){
      if(currentHealth <= minHealth) return true;
      else return false;
  }

  // Will kill the player
  public void Death(){
      objectDeath.Invoke();
      Debug.Log("Object has died");
      Destroy (gameObject, playerDeathTimeLength);
  }

  // --- Collisions --------------------------------------------

  public void OnCollisionEnter2D (Collision2D col){
      Debug.Log ("Object touched something");

      if(col.gameObject.GetComponent<HealthChange>() != null && canThisObjectDamageMe(col)){
        updateCurrentHealth(col.gameObject.GetComponent<HealthChange>().units);
        if (isObjectDead()) Death();
      }
      else{
        Debug.Log ("This object does not have a damage script attached");
      }
  }

  // Triggers when the player collides with a trigger
  public void OnTriggerEnter2D (Collider2D col){
      Debug.Log ("Object touched something");

      if(col.gameObject.GetComponent<HealthChange>() != null && canThisObjectDamageMe_Collider2D(col)){
        updateCurrentHealth(col.gameObject.GetComponent<HealthChange>().units);
        if (isObjectDead()) Death();
      }
      else{
        Debug.Log ("This object does not have a damage script attached");
      }
  }
}
