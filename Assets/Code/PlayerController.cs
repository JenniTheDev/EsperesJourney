// Digx7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement")]
    public Vector2 moveDirection;  // Will be the direction that the player moves in
    public int moveSpeed;          // The move speed of the player

    [Space]
    [Header ("Physics")]
    public Rigidbody2D rb; // The rigid body on the player

    [Space]
    [Header ("Events")]
    public UnityEvent moving;
    public UnityEvent attack;
    public UnityEvent dash;
    public UnityEvent ability;


    // --- Updates -------------------------------------------------------

    public void Awake()
    {
      if(rb == null)
      {
        rb = gameObject.GetComponent<Rigidbody2D>();
      }
    }

    public void FixedUpdate()
    {
      MovePlayer(moveDirection);
    }

    // --- Actions --------------------------------------------------------

    public void MovePlayer(Vector2 input)  // Will control the player Movement
    {
      rb.velocity = new Vector3(input.x, input.y, 0) * moveSpeed * Time.deltaTime;
    }

    public void Attack()
    {
      
    }

    public void Dash()
    {

    }

    public void Ability()
    {

    }
}
