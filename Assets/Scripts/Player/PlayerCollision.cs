using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject capturer = collision.gameObject;
            DeathScript deathManager = GameObject.Find("DeathManager").GetComponent<DeathScript>();
            deathManager.alive = false;
            deathManager.capturer = capturer.transform;

            //Camera.main.transform.parent = null;
            //gameObject.SetActive(false);
            //RespawnPos.Instance.RespawnPlayer(gameObject);
        }
    }
}
