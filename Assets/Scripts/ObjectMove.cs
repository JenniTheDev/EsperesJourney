using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private bool isOn = false;
    [SerializeField] private bool StartOnAwake = false;
    [Header ("Movement")]
      [SerializeField] private int moveSpeed;
      [SerializeField] private Rigidbody2D rb;
      public enum MovementMode {TowardDirection, TowardObject}
      [SerializeField] private MovementMode movementMode = MovementMode.TowardDirection;
      [Space]
    [Header ("Toward Direction Mode")]
      [SerializeField] private Vector3 directionToMove;
    [Header ("Toward Object Mode")]
      [SerializeField] private GameObject objectToMoveTowards;

    public void Awake(){
      if(StartOnAwake) isOn = true;
    }

    public void FixedUpdate(){
      if (isOn && movementMode == MovementMode.TowardDirection){
        rb.velocity = directionToMove * moveSpeed;
      }
      else if (isOn && movementMode == MovementMode.TowardObject){
        directionToMove = objectToMoveTowards.transform.position - gameObject.transform.position;
        Vector3.Normalize(directionToMove);

        rb.velocity = directionToMove * moveSpeed;
      }
    }

    public void toggleIsOn(){
      isOn = !isOn;
    }

    // --- Get and Set Funtions ---------------------------
    public int getMoveSpeed(){
      return moveSpeed;
    }

    public bool getIsOn(){
      return isOn;
    }

    public void setIsOn(bool input){
      isOn = input;
    }

    public void zeroOutVelocity(){
      rb.velocity = new Vector3 (0,0,0);
    }

    public Rigidbody2D getRB(){
      return rb;
    }

    public void setRB(Rigidbody2D _rb){
      rb = _rb;
    }

    public void setDirectionToMoveTo(Vector3 direction){
      directionToMove = direction;
    }

    public void setObjectToMoveTowards(GameObject target){
      objectToMoveTowards = target;
    }
}
