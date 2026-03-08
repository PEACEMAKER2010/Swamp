using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 18f;
    private bool isFacingRight = true;

    private Vector2 movementVector;

    private Vector3 mousePos;

    private InputAction moveAction;
    private InputAction shootAction;

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private BoxCollider2D playerCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }   

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();

        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void Move()
    {
        movementVector = moveAction.ReadValue<Vector2>() * moveSpeed;
        playerRigidBody.linearVelocity = movementVector;
    }

    private void Flip()
    {

        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;

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
}
