using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource lightWorldMusic;
    [SerializeField] private AudioSource darkWorldMusic;

    private static MusicManager instance;
    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MusicManager>();
            }
            return instance;
        }
    }

    public void PlayLightWorldMusic()
    {
        if (darkWorldMusic != null && darkWorldMusic.isPlaying) darkWorldMusic.Pause();
        if (lightWorldMusic != null && !lightWorldMusic.isPlaying) lightWorldMusic.Play();
    }

    public void PlayDarkWorldMusic()
    {
        if (lightWorldMusic != null && lightWorldMusic.isPlaying) lightWorldMusic.Pause();
        if (darkWorldMusic != null && !darkWorldMusic.isPlaying) darkWorldMusic.Play();
    }

    public void PauseAllMusic()
    {
        if (lightWorldMusic != null && lightWorldMusic.isPlaying) lightWorldMusic.Stop();
        if (darkWorldMusic != null && darkWorldMusic.isPlaying) darkWorldMusic.Stop();
    }
}
