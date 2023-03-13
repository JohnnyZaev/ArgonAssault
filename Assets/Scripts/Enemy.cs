using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject crushVFX;
    private void OnParticleCollision(GameObject other)
    {
        var transform1 = transform;
        var VFX = Instantiate(crushVFX, transform1.position, transform1.rotation);
        VFX.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
