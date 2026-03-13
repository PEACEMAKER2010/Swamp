using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    private bool isFacingRight = true;

    public bool IsFacingRight { get { return isFacingRight; } private set { isFacingRight = value;  } }

    private Vector2 movementVector;
    private Vector2 mousePos;

    private InputAction moveAction;

    private State playerState;

    public State PlayerState { get { return playerState;  } private set { playerState = value;  } }

    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] BoxCollider2D playerCollider;
    [SerializeField] Transform playerTransform;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }   

    // Update is called once per frame
    void Update()
    {
        Walk();
        Flip();
        CheckMovementState();

        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void Walk()
    {
        movementVector = moveAction.ReadValue<Vector2>() * moveSpeed;
        playerRigidBody.linearVelocity = movementVector;
    }

    private void Flip()
    {

        float angle = Mathf.Atan2(mousePos.x - playerTransform.position.x, mousePos.y - playerTransform.position.y) * Mathf.Rad2Deg;

        if (angle < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (angle > 0 && isFacingRight == false)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void CheckMovementState()
    {
       if (movementVector == Vector2.zero)
       {
            playerState = State.Idling;
       }
       else if (!movementVector.Equals(Vector2.zero))
       {
            playerState |= State.Walking;
       }
    }


    public enum State
    {
        Idling,
        Walking,
        Shooting,
        Hurting,
        Healing,
        Dying
    }
}
