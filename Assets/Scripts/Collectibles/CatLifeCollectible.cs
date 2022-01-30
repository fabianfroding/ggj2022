using UnityEngine;

public class CatLifeCollectible : MonoBehaviour
{
    [SerializeField] private GameObject catPickupSoundPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CatLifeManager.Instance.AddCollectedCat();
            GameObject g = GameObject.Instantiate(catPickupSoundPrefab, GameObject.Find("Player").transform);
            Destroy(gameObject);
            print("Collision");
        }
    }
}
