// Digx7
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    #region Variables
    [Header("Movement")]
      [Tooltip("Used for debugging purposes.  This will show what direction the player is trying to move in.")]
      public Vector2 moveDirection;  // Will be the direction that the player moves in
      [Tooltip("This is the speed at which the player moves")]
      [SerializeField] private int moveSpeed = 5;          // The move speed of the player
      [Tooltip("This is the speed at which the player dashes")]
      [SerializeField] private int dashSpeed;          // The Dash speed of the player
      [Tooltip("This is the amount of time that the player can not control the character")]
      [SerializeField] private float dashTimeLength = 0.5f;    // The time that the dash lasts
      [SerializeField] private GameObject playerRotater;    // This is the gameObject that rotates in the direction that the player is moving
      [SerializeField] private GameObject blinkPoint;       // This is the point that the player will blind/teleport to

    [Space]
    [Header("Health")]
      [Tooltip("This is the players current health")]
      [SerializeField] int currentHealth = 100;
      [Tooltip("This is the maximum players health")]
      [SerializeField] int maxHealth = 100;
      [Tooltip("This is the minimum players health.  If the current health ever equals this the player will die")]
      [SerializeField] int minHealth = 0;
      [SerializeField] int currentNumberOfHealthPacks = 3;
      [SerializeField] int maxNumberOfHealthPacks = 3;
      [SerializeField] int minNumberOfHealthPacks = 0;
      [Tooltip("List all the GameObject tags of objects that can alter the health of this gameObject")]
      [SerializeField] private List<string> tagsThatCanAffectObjectsHealth;

    // These should be moved to it's own class
    [Space]
    [Header("Death and Respawning")]
      [SerializeField] private bool playerIsDead = false;
      [SerializeField] private float timeToWaitToRespawn = 0.5f;
      [SerializeField] private Vector3 respawnLocation;

    [Space]
    [Header("Basic Attack")]
      [Tooltip("The GameObject that will be spawned when the player does the basic attack")]
      [SerializeField] private GameObject basicAttackObject;          // The object that will be spawned when the player preforms a basic attack
      [Tooltip("The point where the above GameObject will spawn")]
      [SerializeField] private GameObject basicAttackSpawnPoint; // This will be where the basic attack is Instantiated
      [Tooltip("This is the amount of time that the player can not control the character")]
      [SerializeField] private float basicAttackTimeLength = 1; // The length in time that the player will not have control durring the basic attack
      [Tooltip("This is the amount of time that the above object will be in the scene")]
      [SerializeField] private float basicAttackObjectTimeLength = 0.25f; // The Length in time that the attack object will be in the scene

    // These should be moved to their own class
    [Space]
    [Header("Projectile Attack")]
      [Tooltip("The GameObject that will be spawned when the player does the basic attack")]
      [SerializeField] private GameObject projectileObject;          // The object that will be spawned when the player preforms a basic attack
      [Tooltip("The point where the above GameObject will spawn")]
      [SerializeField] private GameObject projectileSpawnPoint; // This will be where the basic attack is Instantiated
      [Tooltip("This is the amount of time that the player can not control the character")]
      [SerializeField] private float projectileTimeLength = 1; // The length in time that the player will not have control durring the basic attack
      [Tooltip("This is the amount of time that the above object will be in the scene")]
      [SerializeField] private float projectileObjectTimeLength = 0.25f; // The Length in time that the attack object will be in the scene
      [Tooltip("The cooldown time of this attack")]
      [SerializeField] private float projectileCoolDownTime = 3.0f; // The Length of the cool down time of this attack
      [Tooltip("The bool controlling weather or not the player can use the projetile ability")]
      [SerializeField] private bool canUseProjectileAttack = true;

    [Space]
    [Header("Animations")]
      [SerializeField] private Animator animator;
      [Tooltip("This is the name of the float handling the movemtent Direction X Float.")]
      [SerializeField] private string movemtentDirectionXFloat;
      [Tooltip("This is the name of the float handling the movemtent Direction Y Float.")]
      [SerializeField] private string movemtentDirectionYFloat;
      [Tooltip("This is the name of the float handling the movemtent Direction Square Magnitude Float.")]
      [SerializeField] private string movemtentDirectionSqrMagnitudeFloat;
      [Tooltip("The lenght of time after the player death event that this gameObject will be destroyed")]
      [SerializeField] private float playerDeathTimeLength = 0.1f; // The Length in time unitl this gameObject is destroyed
      [Tooltip("Shows weather or not the player has control of the character")]
      [SerializeField] private bool playerHasControl = true;   // This controls weather or not the player can do something;

    [Space]
    [Header("Physics")]
      [Tooltip("The Rigidbody2D of the player.  If not set in the inspector it will default to any Rigidbody2D attached to this gameObject")]
      [SerializeField] private Rigidbody2D rb; // The rigid body on the player

    [Space]
    [Header("Events")]
      [SerializeField] private UnityEvent attack;
      [SerializeField] private UnityEvent fireProjectile;
      [SerializeField] private UnityEvent projectileAttackHasCooledDown;
      [SerializeField] private UnityEvent dash;
      [SerializeField] private UnityEvent teleport;
      [SerializeField] private UnityEvent ability;
      [SerializeField] private UnityEvent healthIncrease;
      [SerializeField] private UnityEvent healthDecrease;
      [SerializeField] private UnityEvent playerDied;
      [SerializeField] private UnityEvent playerRespawned;
      [SerializeField] private UnityEvent playerRespawnLocationUpdated;
      [SerializeField] private UnityEvent fullOnHealthPacks;
      [SerializeField] private UnityEvent outOfHealthPack;
      [SerializeField] private UnityEvent healthPackGained;
      [SerializeField] private UnityEvent healthPackUsed;

    #endregion

    #region Updates
    // --- Updates -------------------------------------------------------

    public void Awake() {
        if (IsRigidBodySet());
        else rb = GetRigidBody2DOnThisGameObject();

        if (IsAnimatorSet());
        else animator = GetAnimatorOnThisGameObject();
    }

    public void Update() {
      MovementAnimation();
    }

    public void FixedUpdate() {
        MovePlayer(moveDirection);
    }

    #endregion

    #region Movement
    // --- Movement --------------------------------------------------------

    // Will control the player Movement
    public void MovePlayer(Vector2 input) {
        // moving player
        if (playerHasControl) rb.velocity = new Vector3(input.x, input.y, 0) * moveSpeed * Time.deltaTime;

        // rotating player
        if (playerRotater != null && playerHasControl) {
            if (input.x != 0 || input.y != 0) {
                float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
                playerRotater.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    public void PlayerTeleport() {
        if (playerHasControl) {
            rb.MovePosition(blinkPoint.transform.position);
            teleport.Invoke();
            Debug.Log("Player has teleported");
        }
    }

    public void SetPlayerPosition(Vector3 input) {
        rb.velocity = new Vector3(0, 0, 0);
        gameObject.transform.position = input;
    }

    // Will trigger when the player dashes
    public void Dash() {
        if (playerHasControl) {
            dash.Invoke();
            Debug.Log("The player is dashing");

            StartCoroutine(PlayerDash());
        }
    }

    #endregion

    #region Actions
    // --- Actions ---------------------------------------------------------

    public void Attack() {
        if (playerHasControl) {
            attack.Invoke();
            Debug.Log("The player is attacking");
            StartCoroutine(PlayerAttack());
        }
    }

    public void ProjectileAbility() {
        if (playerHasControl && canUseProjectileAttack) {
            fireProjectile.Invoke();
            Debug.Log("The player is shooting");
            StartCoroutine(PlayerProjectileAbility());
            StartCoroutine(PlayerProjectileAbilityCooldown());
        }
    }

    public void Ability() {
        ability.Invoke();
    }

    #endregion

    #region Animations
    // --- Animations ----------------------------------------------------

    public bool IsAnimatorSet(){
      if(animator != null) return true;
      else return false;
    }

    public Animator GetAnimatorOnThisGameObject(){
      if(gameObject.GetComponent<Animator>() != null) return gameObject.GetComponent<Animator>();
      else return null;
    }

    public void MovementAnimation(){
      if (IsAnimatorSet()){
        animator.SetFloat(movemtentDirectionXFloat, moveDirection.x);
        animator.SetFloat(movemtentDirectionYFloat, moveDirection.y);
        animator.SetFloat(movemtentDirectionSqrMagnitudeFloat, moveDirection.sqrMagnitude);
      }
    }

    #endregion

    #region Health
    // --- Health --------------------------------------------------------

    // Sets the currentHealth to the given input
    public void setCurrentHealth(int input) {
        currentHealth = input;
        Debug.Log("The players currentHealth was set to " + input);
    }

    public bool canThisObjectDamageMe(Collision2D col) {
        foreach (string _tag in tagsThatCanAffectObjectsHealth) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    public bool canThisObjectDamageMe_Collider2D(Collider2D col) {
        foreach (string _tag in tagsThatCanAffectObjectsHealth) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    // Adds the given input to the currentHealth
    public void updateCurrentHealth(int input) {
        currentHealth += input;
        Debug.Log("Something changed the players currentHealth by " + input + " units");

        if (input > 0) healthIncrease.Invoke();
        if (input < 0) healthDecrease.Invoke();
    }

    // created event listener for death

    // Returns true if the currentHealth is less than or equal to the minHealth
    public bool isCharacterDead() {
        if (currentHealth <= minHealth) return true;
        else return false;
    }


    // TODO: add event handler for player death
    // Will kill the player
    public void Death() {
        Debug.Log("Player has died");
        playerDied.Invoke();
        StartCoroutine(PlayerDeathAndRespawn());
    }

    // Sets the position that the players will respawn at
    public void SetPlayerRespawnPosition(Vector3 input) {
        respawnLocation = input;
        playerRespawnLocationUpdated.Invoke();
        Debug.Log("Something updated the players respawn position");
    }

    #endregion

    #region HealthPacks
    // --- HealthPacks ------------------------------------------------

    // Sets the currentHealth to the given input
    public void setCurrentHealthPacks(int input) {
        currentNumberOfHealthPacks = input;
        Debug.Log("The players number of health packs was set to " + input);
    }

    public void updateCurrentHealthPacks(int input) {
        currentNumberOfHealthPacks += input;

        if (currentNumberOfHealthPacks > maxNumberOfHealthPacks) {
            currentNumberOfHealthPacks = maxNumberOfHealthPacks;
            fullOnHealthPacks.Invoke();

            Debug.Log("The Player is already at the maximum number of health packs");
        } else if (currentNumberOfHealthPacks < minNumberOfHealthPacks) {
            currentNumberOfHealthPacks = minNumberOfHealthPacks;
            outOfHealthPack.Invoke();

            Debug.Log("The Player does not have anymore health packs");
        } else {
            if (input > 0) {
                healthPackGained.Invoke();
            }
            if (input < 0) {
                healthPackUsed.Invoke();
                currentHealth = maxHealth;
            }
            Debug.Log("Something changed the players currentHealth by " + input + " units");
        }
    }

    public bool isPlayerOutOfPacks() {
        if (currentNumberOfHealthPacks <= minNumberOfHealthPacks) return true;
        else return false;
    }

    #endregion

    #region Collisions
    // --- Collisions --------------------------------------------

    public bool IsRigidBodySet(){
      if(rb != null) return true;
      else return false;
    }

    public Rigidbody2D GetRigidBody2DOnThisGameObject(){
      if(gameObject.GetComponent<Rigidbody2D>() != null) return gameObject.GetComponent<Rigidbody2D>();
      else return null;
    }

    // Triggers when the player collides with another normal collider
    public void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Player touched something");

        if (col.gameObject.GetComponent<HealthChange>() != null && canThisObjectDamageMe(col)) {
            updateCurrentHealth(col.gameObject.GetComponent<HealthChange>().units);
            if (isCharacterDead()) Death();
        } else if (col.gameObject.GetComponent<UpdateHealthPack>() != null) {
            updateCurrentHealthPacks(col.gameObject.GetComponent<UpdateHealthPack>().units);
        }
    }

    // Triggers when the player collides with a trigger
    public void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Player touched something");

        if (col.gameObject.GetComponent<HealthChange>() != null && canThisObjectDamageMe_Collider2D(col)) {
            updateCurrentHealth(col.gameObject.GetComponent<HealthChange>().units);
            if (isCharacterDead()) Death();
        } else if (col.gameObject.GetComponent<UpdateHealthPack>() != null) {
            updateCurrentHealthPacks(col.gameObject.GetComponent<UpdateHealthPack>().units);
        }
    }

    #endregion

    #region IEnumerators
    // --- IEnumerators -------------------------------------------

    // Will control the player dashing
    public IEnumerator PlayerDash() {
        playerHasControl = false;

        Vector2 dashDirection = moveDirection * dashSpeed;
        rb.AddForce(dashDirection, ForceMode2D.Impulse);
        yield return new WaitForSeconds(dashTimeLength);

        playerHasControl = true;
    }

    public IEnumerator PlayerAttack() {
        playerHasControl = false;

        rb.velocity = new Vector2(0, 0);
        GameObject attack = Instantiate(basicAttackObject, basicAttackSpawnPoint.transform.position, basicAttackSpawnPoint.transform.rotation);
        Destroy(attack, basicAttackObjectTimeLength);
        yield return new WaitForSeconds(basicAttackTimeLength);
        playerHasControl = true;
    }

    public IEnumerator PlayerProjectileAbility() {
        playerHasControl = false;
        canUseProjectileAttack = false;

        rb.velocity = new Vector2(0, 0);
        GameObject projectile = Instantiate(projectileObject, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
        Destroy(projectile, projectileObjectTimeLength);

        yield return new WaitForSeconds(projectileTimeLength);
        playerHasControl = true;
    }

    public IEnumerator PlayerProjectileAbilityCooldown() {
        yield return new WaitForSeconds(projectileCoolDownTime);
        canUseProjectileAttack = true;
        projectileAttackHasCooledDown.Invoke();
        Debug.Log("The Player can use the Projectile attack again");
    }

    public IEnumerator PlayerDeathAndRespawn() {
        playerHasControl = false;
        rb.velocity = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(timeToWaitToRespawn);
        SetPlayerPosition(respawnLocation);
        setCurrentHealth(maxHealth);
        Debug.Log("The Player has respawned");
        playerRespawned.Invoke();

        playerHasControl = true;
    }

    #endregion

    #region EventHandling
    // --- Event Handling ---------------------------------------

    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnPlayerDeath += Death;
    }

    private void Unsubscribe() {
        EventController.Instance.OnPlayerDeath -= Death;
    }

    #endregion
}
