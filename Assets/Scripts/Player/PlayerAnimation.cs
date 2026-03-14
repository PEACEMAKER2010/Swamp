using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerAnimation : MonoBehaviour
{
    private float lockedTill;

    private Vector2 playerMovementVector;

    // Player States
    private int currentState;
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Walk = Animator.StringToHash("Walk");

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerMovement = GetComponent<PlayerMovement>();

        //playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();

        playerMovementVector = playerMovement.PlayerMovementVector;
    }

    private int GetPlayerState()
    {
        // if (Time.time < lockedTill) return currentState;

        return playerMovementVector == Vector2.zero ? Idle : Walk;

        //int LockState(int state, float time)
        //{
        //    lockedTill = Time.time + time;
        //    return state;
        //}
    }

    private void AnimatePlayer()
    {
        var state = GetPlayerState();

        if (state == currentState) return;
        currentState = state;
        playerAnimator.CrossFade(state, 0, 0);
    }

    
}
