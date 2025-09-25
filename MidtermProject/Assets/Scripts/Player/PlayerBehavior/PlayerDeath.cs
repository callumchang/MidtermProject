using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public delegate void OnDeath();
    public static OnDeath onDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        onDeath?.Invoke();
    }
}
