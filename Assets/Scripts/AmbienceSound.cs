using UnityEngine;

public class AmbienceSound : MonoBehaviour
{
    [SerializeField] private AudioClip lightWorldAmbience;
    [SerializeField] private AudioClip darkWorldAmbience;
    private AudioSource audioSrc;

    private static AmbienceSound instance;
    public static AmbienceSound Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AmbienceSound>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayLightWorldAmbience();
    }

    public void PlayLightWorldAmbience()
    {
        audioSrc.Stop();
        audioSrc.clip = lightWorldAmbience;
        audioSrc.Play();
    }

    public void PlayDarkWorldAmbience()
    {
        audioSrc.Stop();
        audioSrc.clip = darkWorldAmbience;
        audioSrc.Play();
    }
}
