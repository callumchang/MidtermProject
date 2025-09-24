using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerSidewaysMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] Animator samuraiAnimator;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        float input = Input.GetAxis("Horizontal");
        float movingDirection = playerRigidbody.linearVelocityX = input * speed;

        if (movingDirection != 0)
        {
            samuraiAnimator.SetBool("isRunning", true);
        }
        else
        {
            samuraiAnimator.SetBool("isRunning", false);
        }


        if (input > 0)
        {
            playerSprite.flipX = false;
        }
        else if (input < 0)
        {
            playerSprite.flipX = true;
        }
    }
}
