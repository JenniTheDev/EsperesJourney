using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [Header ("Movement")]
      [SerializeField] private int moveSpeed;
      [SerializeField] private Rigidbody2D rb;

    public void FixedUpdate(){
      rb.velocity = transform.right * moveSpeed;
    }
}
