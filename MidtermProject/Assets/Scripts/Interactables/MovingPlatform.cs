using System.Collections;
using UnityEngine;

//Adapted from https://youtu.be/GtX1p4cwYOc?si=1GFB4Krbm5gJ9cGs
public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint = 0;
    public Transform[] points;

    private int i;
    private bool vinesActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // transform.position = points[startingPoint].position;
        UseVines.onActivateVines += HoldPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i += 1;
            if (i == points.Length) i = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private IEnumerator StopPlatformMovement()
    {
        float oldSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(5);
        speed = oldSpeed;
        vinesActive = false;
    }

    private void HoldPlatform()
    {
        if (!vinesActive)
        {
            StartCoroutine(StopPlatformMovement());
            vinesActive = true;
            Debug.Log("activated vines");
        }
    }

    public void UpdatePlatformSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
