using UnityEngine;

public class CatLifeCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CatLifeManager.Instance.AddCollectedCat();
            Destroy(gameObject);
        }
    }
}
