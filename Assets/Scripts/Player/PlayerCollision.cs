using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Camera.main.transform.parent = null;
            gameObject.SetActive(false);
            RespawnPos.Instance.RespawnPlayer(gameObject);
        }
    }
}
