using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimationManager : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Vector2 moveDirection;

    public enum MovementListeningMode {Rigidbody2D, Other}

    [Tooltip("Rigidbody2D: Will get the Move Direction data from the Rigidbody2D Velocity\nOther: The Move Direction data will be set by some other source")]
    [SerializeField] private MovementListeningMode movementListeningMode = MovementListeningMode.Rigidbody2D;


    // --- Awake/Updates------------------
    public void Awake() {
        if (!IsAnimatorSet()) animator = GetAnimatorOnThisGameObject();
        if (!IsRigidBodySet()) rb = GetRigidBody2DOnThisGameObject();
    }

    public void Update() {
        if (IsAnimatorSet()) {
            IdleAnimation();
            MovementAnimation();
        }
    }

    public void FixedUpdate() {
        if(movementListeningMode == MovementListeningMode.Rigidbody2D) moveDirection = Vector3.Normalize(rb.velocity);

    }// --- Get/Set --------------------------
    public bool IsAnimatorSet() {
        if (animator != null) return true;
        else return false;
    }

    public bool IsRigidBodySet() {
        if (rb != null) return true;
        else return false;
    }

    public Animator GetAnimatorOnThisGameObject() {
        if (gameObject.GetComponent<Animator>() != null) return gameObject.GetComponent<Animator>();
        else return null;
    }

    public Rigidbody2D GetRigidBody2DOnThisGameObject() {
        if (gameObject.GetComponent<Rigidbody2D>() != null) return gameObject.GetComponent<Rigidbody2D>();
        else return null;
    }

    public void setMoveDirection(Vector2 input) {
      moveDirection = input;
    }
    // --- Animations ----------------------------------
    public void MovementAnimation() {
        if (IsAnimatorSet()) {
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }
    }

    public void AttackAnimation(bool input) {

        if (IsAnimatorSet()) {
            animator.SetBool("Attack", input);

        }
    }

    public void DeathAnimation(bool input) {
        animator.SetBool("Death", input);
    }

    public void IdleAnimation() {
        if (IsAnimatorSet()) {
            if (moveDirection.x >= 0.1 || moveDirection.x <= -0.1 || moveDirection.y >= 0.1 || moveDirection.y <= -0.1) {
                animator.SetFloat("lastMoveHorizontal", -moveDirection.x);
                animator.SetFloat("lastMoveVertical", moveDirection.y);
            }
        }
    }

    public void DashAnimation()
    {
        animator.SetTrigger("Dash");
    }
}
