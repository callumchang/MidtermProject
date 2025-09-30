using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    private bool checkpointActivated;
    [SerializeField] private PlayerDeath deathManager;
    [SerializeField] private Sprite activatedSprite;
    private SpriteRenderer checkpointRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpointRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!checkpointActivated && collision.gameObject.CompareTag("Player"))
        {
            checkpointActivated = true;
            deathManager.UpdateLatestCheckpoint(transform);
            checkpointRenderer.sprite = activatedSprite;
        }
    }
}
