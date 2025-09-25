using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private bool inRange = false;

    public delegate void ShowOutline();
    public static ShowOutline showOutline;

    public delegate void HideOutline();
    public static HideOutline hideOutline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInteractController.onInteract += BreakWall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BreakWall()
    {
        if (inRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            showOutline?.Invoke();
        }
        // Debug.Log("trigger");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            hideOutline?.Invoke();
        }
    }
}
