using UnityEngine;

public class SoundDummy : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.parent = null;
        AudioSource aSrc = GetComponent<AudioSource>();
        aSrc.Play();
        Destroy(gameObject, aSrc.clip.length);
    }
}
