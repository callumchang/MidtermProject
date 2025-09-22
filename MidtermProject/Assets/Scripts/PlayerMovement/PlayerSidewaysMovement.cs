using UnityEngine;

public class PlayerSidewaysMovement : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D playerRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalVelocity = playerRigidbody.linearVelocityX;
        horizontalVelocity = Input.GetAxis("Horizontal") * speed;

        playerRigidbody.linearVelocityX = horizontalVelocity;
    }
}
