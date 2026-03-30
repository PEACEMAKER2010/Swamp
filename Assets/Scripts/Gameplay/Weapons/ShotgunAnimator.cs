using UnityEngine;
using UnityEngine.InputSystem;

public class ShotgunAnimator : MonoBehaviour
{
    private bool locked;

    private float lockedTill;
    private float shootAnimDuration = 0.6f;

    private InputAction shootAction;

    private Animator shotgunAnimator;

    // ShotgunStates

    private int currentState;
    private int lockedState;
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Shoot = Animator.StringToHash("Shoot");

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Attack");

        shotgunAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateShotgun();
    }

    private void AnimateShotgun()
    {
        var state = GetState();

        if (state == currentState) return;
        shotgunAnimator.CrossFade(state, 0, 0);
        currentState = state;
    }

    private int GetState()
    {
        if (Time.time < lockedTill) return currentState;

        if (shootAction.WasPressedThisFrame()) return LockState(Shoot, shootAnimDuration);

        return Idle;

        int LockState(int state, float time)
        {
            lockedTill = Time.time + time;
            return state;
        }
    } 
}
