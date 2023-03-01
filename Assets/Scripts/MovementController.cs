using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputAction movement;
    [SerializeField] private float controlSpeed = 10f;

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
        var horizontalThrow = movement.ReadValue<Vector2>().x;
        var verticalThrow = movement.ReadValue<Vector2>().y;

        _newPosition.x = horizontalThrow * Time.deltaTime * controlSpeed;
        _newPosition.y = verticalThrow * Time.deltaTime * controlSpeed;
        

        transform.localPosition += _newPosition;
    }
}
