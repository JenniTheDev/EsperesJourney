using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasCollided : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col){
      Debug.Log("GameObject: " + gameObject.name + " has collided with: " + col.gameObject.name);
    }
}
