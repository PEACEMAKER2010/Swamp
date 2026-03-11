using UnityEngine;
using UnityEngine.InputSystem;

public class ShotgunController : MonoBehaviour
{
    private Vector2 mousePos;

    [SerializeField] Transform shotgunTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateShotgun();
    }

    private void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void RotateShotgun()
    {
        GetMousePos();

        float angle = Mathf.Atan2(mousePos.x - shotgunTransform.position.x, mousePos.y - shotgunTransform.position.y) * Mathf.Rad2Deg;

        shotgunTransform.rotation = Quaternion.Euler(0, 0, angle);

        //shotgunTransform.LookAt(mousePos);
    }
}
