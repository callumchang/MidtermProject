using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private bool inRange = false;

    public SpriteRenderer outlineRenderer;

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
            outlineRenderer.enabled = true;
        }
        // Debug.Log("trigger");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            outlineRenderer.enabled = false;
        }
    }
}
