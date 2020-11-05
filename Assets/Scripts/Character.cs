using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]

public class Character : MonoBehaviour, IMoveableChar {

    // If using force
    //[SerializeField] private float moveForce = 3.0f;
    // For Velocity
    [SerializeField] private float unitsPerSecond = 5;

    private Rigidbody2D rb;
    private LayerMask wallMask;

    #region MonoBehavior

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        wallMask = LayerMask.NameToLayer("Wall");
    }

    #endregion

    #region Methods

    public void MoveUp() {
        MoveCharacter(CharDirection.Up);
    }

    public void MoveDown() {
        MoveCharacter(CharDirection.Down);
    }

    public void MoveLeft() {
        MoveCharacter(CharDirection.Left);
    }


    public void MoveRight() {
        MoveCharacter(CharDirection.Right);
    }

    // Velocity instead? 
    private void MoveCharacter(CharDirection dir) {
        //var moveTowards = Vector2.up * ((dir == CharDirection.Up) ? moveForce : -moveForce);
        // rb.AddForce(moveTowards);

        // moveTowards = Vector2.left * ((dir == CharDirection.Left) ? moveForce : -moveForce);
        // rb.AddForce(moveTowards);
        if (dir == CharDirection.Up) {
            rb.velocity = new Vector2(0, unitsPerSecond);
        }
        if (dir == CharDirection.Down) {
            rb.velocity = new Vector2(0, -unitsPerSecond);
        }
        if (dir == CharDirection.Left) {
            rb.velocity = new Vector2(-unitsPerSecond, 0);
        }
        if (dir == CharDirection.Right) {
            rb.velocity = new Vector2(unitsPerSecond, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == wallMask) {
            rb.velocity = Vector2.zero;
            Debug.Log("wall");
        }
    }

    #endregion
}
