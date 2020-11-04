using System.Collections;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_Attack") BreakIt();
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player_Attack") BreakIt();
    }

    public void BreakIt()
    {
        Destroy(this.gameObject);
    }
}
