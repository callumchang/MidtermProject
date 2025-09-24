using UnityEngine;

public class UseVines : MonoBehaviour
{
    private bool inRange = false;
    private MovingPlatform movingPlatform;

    public delegate void ActivateVines();
    public static ActivateVines onActivateVines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movingPlatform = GetComponent<MovingPlatform>();
        PlayerInteractController.onInteract += ActivateVinesHelper;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateVinesHelper()
    {
        if (inRange)
        {
            onActivateVines?.Invoke();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
