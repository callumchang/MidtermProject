using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClamLogic : MonoBehaviour
{
    [SerializeField] Sprite closedClam;
    [SerializeField] Sprite openClam;
    [SerializeField] float closeTime;
    [SerializeField] float openTime;

    private SpriteRenderer clamSpirte;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clamSpirte = GetComponent<SpriteRenderer>();
        StartCoroutine(shutClam());
    }

    private IEnumerator shutClam()
    {
        while (true)
        {
            yield return new WaitForSeconds(openTime);
            clamSpirte.sprite = closedClam;
            gameObject.GetComponent<Collider2D>().isTrigger = true;

            yield return new WaitForSeconds(closeTime);
            clamSpirte.sprite = openClam;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
