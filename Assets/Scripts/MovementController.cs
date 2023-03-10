using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputAction rocketMovement;
    [SerializeField] private InputAction rocketFire;
    
    [Header("General Setup Settings")]
    [SerializeField] private GameObject[] lasers;
    [Tooltip("How fast ship moving up and down based upon player speed")]
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRange = 5f;
    [SerializeField] private float positionPitchFactor = -2f;
    [SerializeField] private float controlPitchFactor = -10;
    [SerializeField] private float positionYawFactor = 5f;
    [SerializeField] private float controlRollFactor = 5f;

    private Vector3 _newPosition;

    private float _horizontalThrow;
    private float _verticalThrow;

    private void OnEnable()
    {
        rocketMovement.Enable();
        rocketFire.Enable();
    }

    private void OnDisable()
    {
        rocketMovement.Disable();
        rocketFire.Disable();
    }

    private void Update()
    {
        PerformThrow();
        PerformRotation();
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        if (rocketFire.ReadValue<float>() > 0.5f)
        {
            foreach (var laser in lasers)
            {
                EmissionSwitcher(laser, true);
            }
        }
        else
        {
            foreach (var laser in lasers)
            {
                EmissionSwitcher(laser, false);
            }
        }
    }

    private void EmissionSwitcher(GameObject laser, bool state)
    {
        var emission = laser.GetComponent<ParticleSystem>().emission;
        emission.enabled = state;
    }

    private void PerformRotation()
    {
        var localPosition = transform.localPosition;
        var pitch = localPosition.y * positionPitchFactor + _verticalThrow * controlPitchFactor;
        var yaw = localPosition.x * positionYawFactor;
        var roll = _horizontalThrow * -controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void PerformThrow()
    {
        _horizontalThrow = rocketMovement.ReadValue<Vector2>().x;
        _verticalThrow = rocketMovement.ReadValue<Vector2>().y;

        var localPosition = transform.localPosition;
        _newPosition.x = Mathf.Clamp(localPosition.x + _horizontalThrow * Time.deltaTime * controlSpeed, -xRange, xRange);
        _newPosition.y = Mathf.Clamp(localPosition.y + _verticalThrow * Time.deltaTime * controlSpeed, -yRange, yRange);


        localPosition = _newPosition;
        transform.localPosition = localPosition;
    }
}
