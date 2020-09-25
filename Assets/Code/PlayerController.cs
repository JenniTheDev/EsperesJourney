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
    [SerializeField] private bool isDashing = false; // Used by some functions to tell if the player is currently dashing
    [Tooltip ("This is the amount of time that the player can not control the character")]
    [SerializeField] private float dashTimeLength = 0.5f;    // The time that the dash lasts

    [Space]
    [Header ("Physics")]
    [Tooltip ("The Rigidbody2D of the player.  If not set in the inspector it will default to any Rigidbody2D attached to this gameObject")]
    [SerializeField] private  Rigidbody2D rb; // The rigid body on the player

    [Space]
    [Header ("Events")]
    [SerializeField] private  UnityEvent attack;
    [SerializeField] private  UnityEvent dash;
    [SerializeField] private  UnityEvent ability;


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
      if (!isDashing) rb.velocity = new Vector3(input.x, input.y, 0) * moveSpeed * Time.deltaTime;
    }

    public void Attack()
    {
      attack.Invoke();
      Debug.Log("The player is attacking");
    }

    // Will trigger when the player dashes
    public void Dash(){
      dash.Invoke();
      Debug.Log("The player is dashing");

      StartCoroutine(PlayerDash());
    }

    public void Ability(){
      ability.Invoke();
    }

    // --- IEnumerators -------------------------------------------

     // Will control the player dashing
    public IEnumerator PlayerDash(){
      isDashing = true;

      Vector2 dashDirection = moveDirection * dashSpeed;
      rb.AddForce(dashDirection, ForceMode2D.Impulse);
      yield return new WaitForSeconds(dashTimeLength);
      
      isDashing = false;
    }
}
