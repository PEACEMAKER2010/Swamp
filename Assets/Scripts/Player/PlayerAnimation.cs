using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private Animator playerAnimator;

    private int playerStateValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerStateInt();
    }

    private void CheckPlayerState()
    {
        playerStateValue = (int)playerMovement.PlayerState;
    }

    private void SetPlayerStateInt()
    {
        CheckPlayerState();

        playerAnimator.SetInteger("PlayerStateInt", playerStateValue);
    }
}
