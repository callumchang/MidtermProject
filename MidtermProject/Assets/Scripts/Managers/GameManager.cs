using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string sceneReloadKey;

    void Awake()
    {
        makeGameManagerSingleton();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(sceneReloadKey)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void makeGameManagerSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
