using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputAction movement;
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRange = 5f;

    private Vector3 _newPosition;

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void Update()
    {
        PerformThrow();
        PerfomRotation();
    }

    private void PerfomRotation()
    {
        float pitch, yaw, roll;
        
        transform.localRotation = Quaternion.Euler(30f, -30f, 0f);
    }

    private void PerformThrow()
    {
        var horizontalThrow = movement.ReadValue<Vector2>().x;
        var verticalThrow = movement.ReadValue<Vector2>().y;

        var localPosition = transform.localPosition;
        _newPosition.x = Mathf.Clamp(localPosition.x + horizontalThrow * Time.deltaTime * controlSpeed, -xRange, xRange);
        _newPosition.y = Mathf.Clamp(localPosition.y + verticalThrow * Time.deltaTime * controlSpeed, -yRange, yRange);


        localPosition = _newPosition;
        transform.localPosition = localPosition;
    }
}
