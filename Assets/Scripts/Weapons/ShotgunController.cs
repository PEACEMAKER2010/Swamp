using UnityEngine;
using UnityEngine.InputSystem;

public class ShotgunController : MonoBehaviour
{
    private bool isFlipped = false;

    private float nextShotTime;
    private float timeBetweenShots;

    private Vector3 mousePos;

    private InputAction shootAction;

    [SerializeField] Animator shotgunAnimator;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Transform shotgunTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        RotateShotgun();

        ShootShotgun();
    }

    private void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void RotateShotgun()
    {
        GetMousePos();

        Vector2 aimDirection = mousePos - shotgunTransform.position;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        angle = ClampShotgunAngle(angle, -35f, 35f, -145, 145f, playerMovement.IsFacingRight);

        shotgunTransform.rotation = Quaternion.Euler(0, 0, angle);

        if (playerMovement.IsFacingRight == false && isFlipped == true)
        {
            isFlipped = false;

            shotgunTransform.localScale = new Vector3(shotgunTransform.localScale.x * -1, shotgunTransform.localScale.y * -1, shotgunTransform.localScale.z);
        }
        else if (playerMovement.IsFacingRight == true && isFlipped == false)
        {
            isFlipped = true;

            shotgunTransform.localScale = AbsoluteVector3(shotgunTransform.localScale);
        }

    }

    private void ShootShotgun()
    {
        if (shootAction.IsPressed())
        {
            shotgunAnimator.SetTrigger("shootShotgun");
        }
    }

    private float ClampShotgunAngle(float angle, float lowRight, float highRight, float lowLeft, float highLeft, bool isGunFacingRight)
    {
        if (isGunFacingRight == true)
        {
            return Mathf.Clamp(angle, lowRight, highRight);
        }
        else
        {
            if (angle < 180 && angle > 0)
            {
                return Mathf.Clamp(angle, highLeft, 180);
            }
            else
            {
                return Mathf.Clamp(angle, -180, lowLeft);
            }
        }    
    }

    private Vector3 AbsoluteVector3 (Vector3 vector)
    {
        return new Vector3 (Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }
}
