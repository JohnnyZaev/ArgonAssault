using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float loadDelay = 2f;
    
    private void OnTriggerEnter(Collider other)
    {
        StartCrushSequence();
    }

    private void StartCrushSequence()
    {
        GetComponent<MovementController>().enabled = false;
        Invoke(nameof(ReloadLevel), loadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
