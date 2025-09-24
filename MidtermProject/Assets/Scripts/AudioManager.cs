using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [Header("Volumes")]
    [Range(0f, 1f)][SerializeField] float musicVolume = 1f;
    [Range(0f, 1f)][SerializeField] float sfxVolume = 1f;

    private bool isMuted;

    void Awake()
    {
        makeAudioManagerSingleton();
        makeMusicSourceLoopable();
        applyVolumes();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playSFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    public void playMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (musicSource.clip == clip && musicSource.isPlaying) return;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void setMuted(bool muted)
    {
        isMuted = muted;
        AudioListener.volume = muted ? 0f : 1f;
    }

    private void makeAudioManagerSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void makeMusicSourceLoopable()
    {
        musicSource.loop = true;
    }

    private void applyVolumes()
    {
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;
    }
}
