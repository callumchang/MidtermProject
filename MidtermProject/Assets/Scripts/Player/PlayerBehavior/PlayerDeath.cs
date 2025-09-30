using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject checkpointParticles;
    Transform latestCheckpoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spikes.onDeath += ReturnToCheckpoint;
        GameManager.restartFromCheckpoint += ReturnToCheckpoint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Spikes.onDeath -= ReturnToCheckpoint;
        GameManager.restartFromCheckpoint -= ReturnToCheckpoint;
    }

    private void ReturnToCheckpoint()
    {
        transform.position = latestCheckpoint.position;
        // Debug.Log("Returned to checkpoint");
    }

    public void UpdateLatestCheckpoint(Transform checkpoint)
    {
        latestCheckpoint = checkpoint;
        checkpointParticles.transform.position = checkpoint.position;
        // Debug.Log("Updated checkpoint");
    }
}
