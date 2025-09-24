using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    public string interactButton;

    public delegate void OnInteract();
    public static OnInteract onInteract;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactButton)) onInteract?.Invoke();
    }
}
