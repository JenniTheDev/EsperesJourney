using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [Header ("Movement")]
      [SerializeField] private Vector3 moveDirection = new Vector3 (1,0,0);
      [SerializeField] private int moveSpeed;
      [SerializeField] private Rigidbody2D rb;

    public void FixedUpdate(){
      rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }
}
