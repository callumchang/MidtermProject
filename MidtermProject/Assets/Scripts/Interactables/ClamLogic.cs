using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClamLogic : MonoBehaviour
{
    [SerializeField] Sprite closedClam;
    [SerializeField] Sprite openClam;
    [SerializeField] float closeTime;
    [SerializeField] float openTime;

    private SpriteRenderer clamSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clamSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(shutClam());
    }

    private IEnumerator shutClam()
    {
        while (true)
        {
            yield return new WaitForSeconds(openTime);
            clamSprite.sprite = closedClam;
            clamSprite.sortingLayerName = "Default";
            gameObject.GetComponent<Collider2D>().isTrigger = true;

            yield return new WaitForSeconds(closeTime);
            clamSprite.sprite = openClam;
            clamSprite.sortingLayerName = "Background";
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
