using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public delegate void OnDeath();
    public static OnDeath onDeath;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onDeath?.Invoke();
        }
    }

    // public void RestartScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //     PlayerDeath.onDeath -= RestartScene;
    // }
}
