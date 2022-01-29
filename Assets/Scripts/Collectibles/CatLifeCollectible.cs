using UnityEngine;

public class CatLifeCollectible : MonoBehaviour
{
    [SerializeField] private GameObject catPickupSoundPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CatLifeManager.Instance.AddCollectedCat();
            GameObject.Instantiate(catPickupSoundPrefab);
            Destroy(gameObject);
            print("Collision");
        }
    }
}
