// Brought to you by Jenni
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
    [SerializeField] private float unitsPerSecond = 5.0f;

    private Rigidbody2D character;
    private LayerMask wallMask;
    private LayerMask healthPotMask;

    #region MonoBehavior

    // Should this be start instead of Awake ?
    private void Awake() {
        character = GetComponent<Rigidbody2D>();
        wallMask = LayerMask.NameToLayer("Wall");
        healthPotMask = LayerMask.NameToLayer("HealthPot");
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
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
        // character.AddForce(moveTowards);

        // moveTowards = Vector2.left * ((dir == CharDirection.Left) ? moveForce : -moveForce);
        // character.AddForce(moveTowards);
        if (dir == CharDirection.Up) {
            character.velocity = new Vector2(0, unitsPerSecond);
        }
        if (dir == CharDirection.Down) {
            character.velocity = new Vector2(0, -unitsPerSecond);
        }
        if (dir == CharDirection.Left) {
            character.velocity = new Vector2(-unitsPerSecond, 0);
        }
        if (dir == CharDirection.Right) {
            character.velocity = new Vector2(unitsPerSecond, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == wallMask) {
            // This doesn't stop the player from going through the wall 
            character.velocity = Vector2.zero;
            Debug.Log("wall");
        } 

        // TODO This is not working, does not say player touched the health pot, what did I do wrong? 
        if (collision.gameObject.layer == healthPotMask) {
            EventController.Instance.BroadcastHealthPotFind();
            Debug.Log("Player has touched a health pot");
        }
    }

    
    

    private void Subscribe() {
        Unsubscribe();
        // EventController events character needs to know about +=
        
       
    }

    private void Unsubscribe() {
        // -= events listed above
    }

    #endregion
}
