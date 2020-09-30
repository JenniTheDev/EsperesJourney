// Digx7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement")]
      [Tooltip ("Used for debugging purposes.  This will show what direction the player is trying to move in.")]
      public Vector2 moveDirection;  // Will be the direction that the player moves in
      [Tooltip ("This is the speed at which the player moves")]
      [SerializeField] private int moveSpeed;          // The move speed of the player
      [Tooltip ("This is the speed at which the player dashes")]
      [SerializeField] private int dashSpeed;          // The Dash speed of the player
      [Tooltip ("This is the amount of time that the player can not control the character")]
      [SerializeField] private float dashTimeLength = 0.5f;    // The time that the dash lasts
      [SerializeField] private GameObject playerRotater;    // This is the gameObject that rotates in the direction that the player is moving
      [SerializeField] private GameObject blinkPoint;       // This is the point that the player will blind/teleport to

    [Space]
    [Header ("Health")]
      [Tooltip ("This is the players current health")]
      [SerializeField] int currentHealth = 100;
      [Tooltip ("This is the maximum players health")]
      [SerializeField] int maxHealth = 100;
      [Tooltip ("This is the minimum players health.  If the current health ever equals this the player will die")]
      [SerializeField] int minHealth = 0;
      [Tooltip ("List all the GameObject tags of objects that can alter the health of this gameObject")]
      [SerializeField] private List<string> tagsThatCanAffectObjectsHealth;

    [Space]
    [Header ("Attacking and Abilities")]
      [Tooltip ("The GameObject that will be spawned when the player does the basic attack")]
      [SerializeField] private GameObject basicAttackObject;          // The object that will be spawned when the player preforms a basic attack
      [Tooltip ("The point where the above GameObject will spawn")]
      [SerializeField] private GameObject basicAttackSpawnPoint; // This will be where the basic attack is Instantiated
      [Tooltip ("This is the amount of time that the player can not control the character")]
      [SerializeField] private float basicAttackTimeLength = 1; // The length in time that the player will not have control durring the basic attack
      [Tooltip ("This is the amount of time that the above object will be in the scene")]
      [SerializeField] private float basicAttackObjectTimeLength = 0.25f; // The Length in time that the attack object will be in the scene

    [Space]
    [Header ("Other")]
      [Tooltip ("The lenght of time after the player death event that this gameObject will be destroyed")]
      [SerializeField] private float playerDeathTimeLength = 0.1f; // The Length in time unitl this gameObject is destroyed
      [Tooltip ("Shows weather or not the player has control of the character")]
      [SerializeField] private bool playerHasControl = true;   // This controls weather or not the player can do something;

    [Space]
    [Header ("Physics")]
      [Tooltip ("The Rigidbody2D of the player.  If not set in the inspector it will default to any Rigidbody2D attached to this gameObject")]
      [SerializeField] private  Rigidbody2D rb; // The rigid body on the player

    [Space]
    [Header ("Events")]
      [SerializeField] private  UnityEvent attack;
      [SerializeField] private  UnityEvent dash;
      [SerializeField] private  UnityEvent teleport;
      [SerializeField] private  UnityEvent ability;
      [SerializeField] private  UnityEvent healthIncrease;
      [SerializeField] private  UnityEvent healthDecrease;
      [SerializeField] private  UnityEvent playerDeath;


    // --- Updates -------------------------------------------------------

    public void Awake(){
      if(rb == null)
      {
        rb = gameObject.GetComponent<Rigidbody2D>();
      }
    }

    public void FixedUpdate(){
      MovePlayer(moveDirection);
    }

    // --- Actions --------------------------------------------------------

    // Will control the player Movement
    public void MovePlayer(Vector2 input){
      // moving player
      if (playerHasControl) rb.velocity = new Vector3(input.x, input.y, 0) * moveSpeed * Time.deltaTime;

      // rotating player
      if (playerRotater != null){
        if (input.x != 0 || input.y != 0){
          float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
          playerRotater.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
      }
    }

    public void PlayerTeleport(){
      rb.MovePosition(blinkPoint.transform.position);
      teleport.Invoke();
      Debug.Log("Player has teleported");
    }

    public void Attack(){
      if(playerHasControl){
        attack.Invoke();
        Debug.Log("The player is attacking");
        StartCoroutine(PlayerAttack());
      }
    }

    // Will trigger when the player dashes
    public void Dash(){
      if (playerHasControl){
        dash.Invoke();
        Debug.Log("The player is dashing");

        StartCoroutine(PlayerDash());
      }
    }

    public void Ability(){
      ability.Invoke();
    }

    // --- Health --------------------------------------------------------

    // Sets the currentHealth to the given input
    public void setCurrentHealth(int input){
      currentHealth = input;
      Debug.Log ("The players currentHealth was set to " + input);
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
      Debug.Log ("Something changed the players currentHealth by " + input + " units");

      if (input > 0) healthIncrease.Invoke();
      if (input < 0) healthDecrease.Invoke();
    }

    // Returns true if the currentHealth is less than or equal to the minHealth
    public bool isCharacterDead(){
      if(currentHealth <= minHealth) return true;
      else return false;
    }

    // Will kill the player
    public void Death(){
      playerDeath.Invoke();
      Debug.Log("Player has died");
      Destroy (gameObject, playerDeathTimeLength);
    }

    // --- Collisions --------------------------------------------

    // Triggers when the player collides with another normal collider
    public void OnCollisionEnter2D (Collision2D col){
      Debug.Log ("Player touched something");

      if(col.gameObject.GetComponent<damage>() != null && canThisObjectDamageMe(col)){
        updateCurrentHealth(col.gameObject.GetComponent<damage>().units);
        if (isCharacterDead()) Death();
      }
      else{
        Debug.Log ("This object does not have a damage script attached");
      }
    }

    // Triggers when the player collides with a trigger
    public void OnTriggerEnter2D (Collider2D col){
      Debug.Log ("Player touched something");

      if(col.gameObject.GetComponent<damage>() != null && canThisObjectDamageMe_Collider2D(col)){
        updateCurrentHealth(col.gameObject.GetComponent<damage>().units);
        if (isCharacterDead()) Death();
      }
      else{
        Debug.Log ("This object does not have a damage script attached");
      }
    }

    // --- IEnumerators -------------------------------------------

     // Will control the player dashing
    public IEnumerator PlayerDash(){
      playerHasControl = false;

      Vector2 dashDirection = moveDirection * dashSpeed;
      rb.AddForce(dashDirection, ForceMode2D.Impulse);
      yield return new WaitForSeconds(dashTimeLength);

      playerHasControl = true;
    }

    public IEnumerator PlayerAttack(){
      playerHasControl = false;

      rb.velocity = new Vector2(0,0);
      GameObject attack = Instantiate(basicAttackObject, basicAttackSpawnPoint.transform.position, basicAttackSpawnPoint.transform.rotation);
      Destroy(attack, basicAttackObjectTimeLength);

      yield return new WaitForSeconds(basicAttackTimeLength);
      playerHasControl = true;
    }
}
