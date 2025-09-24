using UnityEngine;

public class UnitizedJumps : MonoBehaviour
{
    [SerializeField] float maximumJumpHeight;
    [SerializeField] float forceOfGravity = 1;
    [SerializeField] float fallingForceOfGravity = 5;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] AudioClip jumpNoise;

    private Rigidbody2D playerRb;
    private BoxCollider2D playerHitBox;
    public bool isGrounded;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerHitBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfGround();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            handleJump();
        }

        preventFloatJump();
        // Debug.Log("The player y velocity: " + playerRb.linearVelocity.y + "\n" + "The player gravity: " + playerRb.gravityScale);
    }

    private void handleJump()
    {
        float jumpForce = Mathf.Sqrt(maximumJumpHeight * -2 * (Physics2D.gravity.y * playerRb.gravityScale)); // Found this equation from here: https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics
        // Debug.Log(playerRb.gravityScale);
        // Debug.Log(Physics2D.gravity.y);
        // Debug.Log("Jump force is: " + jumpForce);
        playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        AudioManager.Instance?.playSFX(jumpNoise);
    }

    private void preventFloatJump()
    {
        if (playerRb.linearVelocity.y >= 0)
        {
            playerRb.gravityScale = forceOfGravity;
        }
        else if (playerRb.linearVelocity.y < 0)
        {
            playerRb.gravityScale = fallingForceOfGravity;
        }
    }

    private void checkIfGround()
    {
        Bounds hitboxBounds = playerHitBox.bounds;
        Vector2 pointA = new Vector2(hitboxBounds.min.x, hitboxBounds.min.y - .05f);
        Vector2 pointB = new Vector2(hitboxBounds.max.x, hitboxBounds.min.y);
        Collider2D onGround = Physics2D.OverlapArea(pointA, pointB, groundLayer);

        isGrounded = onGround != null;
        // Debug.Log(isGrounded);
    }
}
