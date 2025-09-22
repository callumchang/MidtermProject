using UnityEngine;

public class PlayerSidewaysMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] Animator samuraiAnimator;

    private Rigidbody2D playerRigidbody;
    private Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        float input = Input.GetAxis("Horizonal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);

        if (input != 0)
        {
            samuraiAnimator.SetBool("isRunning", true);
        } 

        samuraiAnimator.SetBool("isRunning", false);
    }
}
