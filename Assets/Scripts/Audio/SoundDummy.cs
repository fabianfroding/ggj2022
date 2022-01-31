using UnityEngine;

public class SoundDummy : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.parent = null;

        // TODO: Cleanup
        if (gameObject.name == "SND_FootstepsEnemy")
        {
            gameObject.transform.parent = GameObject.Find("Player").transform;
        }

        AudioSource aSrc = GetComponent<AudioSource>();
        if (aSrc != null)
        {
            aSrc.Play();
            Destroy(gameObject, aSrc.clip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
