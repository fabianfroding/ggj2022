using UnityEngine;

// This script can be attached to spawned sound prefabs instead of having an AudioSourceComponent on the triggering/parent game object.
// This ensures that the sound will finish playing even after the triggering/parent game object has been destroyed.
public class SoundDummy : MonoBehaviour
{
    [Tooltip("Determines if the created sound should stay in the spawned position or follow the parent game object.")]
    [SerializeField] private bool detachFromParent = true;

    private void Start()
    {
        if (detachFromParent) gameObject.transform.parent = null;

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
