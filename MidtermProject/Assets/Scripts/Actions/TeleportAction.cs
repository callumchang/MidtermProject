using Unity.VisualScripting;
using UnityEngine;

public class teleport : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private GameObject locationOfTeleporter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(locationOfTeleporter);
        if (Input.GetButtonDown("Teleport") && locationOfTeleporter != null)
        {
            transform.position = locationOfTeleporter.GetComponent<TeleporterSpotLogic>().getTeleportSpot().position;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter Spot"))
        {
            locationOfTeleporter = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == locationOfTeleporter)
        {
            locationOfTeleporter = null;
        }
    }
}
