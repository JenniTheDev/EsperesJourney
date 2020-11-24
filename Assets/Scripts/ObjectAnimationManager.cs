using UnityEngine;

public class ObjectAnimationManager : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Vector2 moveDirection;

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
        moveDirection = Vector3.Normalize(rb.velocity);
    }

    // --- Get/Set --------------------------
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

    // --- Animations ----------------------------------
    public void MovementAnimation() {
        if (IsAnimatorSet()) {
            animator.SetFloat("movemtentDirectionXFloat", moveDirection.x);
            animator.SetFloat("movemtentDirectionYFloat", moveDirection.y);
            animator.SetFloat("movemtentDirectionSqrMagnitudeFloat", moveDirection.sqrMagnitude);
        }
    }

    public void IdleAnimation() {
        if (IsAnimatorSet()) {
            if (moveDirection.x >= 0.1 || moveDirection.x <= -0.1 || moveDirection.y >= 0.1 || moveDirection.y <= -0.1) {
                animator.SetFloat("lastMoveHorizontal", -moveDirection.x);
                animator.SetFloat("lastMoveVertical", moveDirection.y);
            }
        }
    }
}