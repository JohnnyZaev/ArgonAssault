using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputAction movement;

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
        
        Debug.Log(horizontalThrow);
    }
}
