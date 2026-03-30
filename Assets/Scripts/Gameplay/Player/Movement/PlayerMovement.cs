using UnityEngine;
using UnityEngine.InputSystem;
using Gameplay.Player.Input;

namespace Gameplay.Player.Movement
{
    public class PlayerMovement : MonoBehaviour, IMotor<PlayerInputFrame>
    {
        private float moveSpeed = 10f;
        private bool isFacingRight = true;

        public bool IsFacingRight { get { return isFacingRight; } private set { isFacingRight = value;  } }

        private Vector2 playerMovementVector;
        private Vector2 mousePos;


        public Vector2 PlayerMovementVector { get { return playerMovementVector;  } private set { playerMovementVector = value;  } }

        public Rigidbody2D playerRigidBody { get; private set; }
        public BoxCollider2D playerCollider { get; private set; }
        public Transform playerTransform { get; private set; }
        public PlayerInputFrame CurrentInputFrame { get; private set; }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody2D>();
            playerCollider = GetComponent<BoxCollider2D>();
            playerTransform = GetComponent<Transform>();
        }   

        // Update is called once per frame
        public void Tick(PlayerInputFrame frame)
        {
            CurrentInputFrame = frame;
            Walk(frame.MovementDirection);
            Flip();

            mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }

        private void Walk(Vector2 movementDirection)
        {
            playerMovementVector = movementDirection * moveSpeed;
            playerRigidBody.linearVelocity = playerMovementVector;
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
    }
}