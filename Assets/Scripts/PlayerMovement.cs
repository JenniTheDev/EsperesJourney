using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpd = 1f;

    public Rigidbody2D rb;
    public bool canMove;

    Vector2 movement;

    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        canMove = true;

    }

    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //Frame-rate independent
    private void FixedUpdate()
    {












        if (canMove)
        {
            rb.MovePosition(rb.position + movement * moveSpd * Time.fixedDeltaTime);
        }
    }
}
