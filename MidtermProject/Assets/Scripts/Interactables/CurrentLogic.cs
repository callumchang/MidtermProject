using Unity.VisualScripting;
using UnityEngine;

public class CurrentLogic : MonoBehaviour
{
    [SerializeField] Vector2 force;
    [SerializeField] float power;

    void Start()
    {
        // PlayerInteractController.onInteract += deactivateCurrent;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D player = collision.attachedRigidbody;

            if (player != null)
            {
                player.AddForce(force * power, ForceMode2D.Force);
            }
        }
    }


    void deactivateCurrent()
    {
        Destroy(gameObject);
    }
}
