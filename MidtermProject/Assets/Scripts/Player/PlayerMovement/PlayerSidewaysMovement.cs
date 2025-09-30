using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerSidewaysMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] Animator playerAnimator;

    [SerializeField] VisualEffect movementParticles;

    public int bubbleSpawnRate;

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
            playerAnimator.SetBool("isRunning", true);
            movementParticles.SetInt("SpawnRate", bubbleSpawnRate);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
            movementParticles.SetInt("SpawnRate", 0);
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
