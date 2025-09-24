using UnityEngine;

public class PlayerCharacterAnimator : MonoBehaviour
{
    Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
