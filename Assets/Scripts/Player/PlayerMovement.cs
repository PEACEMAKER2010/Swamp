using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    private bool isFacingRight = true;

    private Vector2 movementVector;
    private Vector2 mousePos;

    private InputAction moveAction;
    private InputAction shootAction;

    private State playerState;

    public State PlayerState { get { return playerState;  } private set { playerState = value;  } }

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private Transform playerTransform;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
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
            transform.Rotate(0, 180, 0);
        }
        else if (angle > 0 && isFacingRight == false)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
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
