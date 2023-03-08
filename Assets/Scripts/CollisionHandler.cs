using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{this.name} collided with {collision.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} triggered with {other.gameObject.name}");
    }
}
