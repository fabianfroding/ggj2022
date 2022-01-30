using UnityEngine;

public class SoundDummy : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.parent = null;
        if (gameObject.name == "SND_FootstepsEnemy")
        {
            gameObject.transform.parent = GameObject.Find("Player").transform;
        }
        AudioSource aSrc = GetComponent<AudioSource>();
        aSrc.Play();
        Destroy(gameObject, aSrc.clip.length);
    }
}
