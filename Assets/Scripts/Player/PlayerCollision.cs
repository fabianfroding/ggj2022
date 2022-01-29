using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject playerDeathSoundPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject capturer = collision.gameObject;
            DeathScript deathManager = GameObject.Find("DeathManager").GetComponent<DeathScript>();
            deathManager.alive = false;
            deathManager.capturer = capturer;

            Debug.Log("Death");
            GameObject.Instantiate(playerDeathSoundPrefab);

            //Camera.main.transform.parent = null;
            //gameObject.SetActive(false);
            //RespawnPos.Instance.RespawnPlayer(gameObject);
        }
    }
}
