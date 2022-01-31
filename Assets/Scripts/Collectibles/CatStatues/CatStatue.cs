
using UnityEngine;

public class CatStatue : MonoBehaviour
{
    [SerializeField] private GameObject collectStatueSoundPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(EditorConstants.TAG_PLAYER))
        {
            CatStatueManager.Instance.AddStatue();

            if (collectStatueSoundPrefab != null)
            {
                GameObject collectStatueSound = Instantiate(collectStatueSoundPrefab);
                collectStatueSound.transform.position = transform.position;
            }
            
            Destroy(gameObject);
        }
    }
}
