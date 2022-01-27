using System.Collections;
using UnityEngine;

public class RespawnPos : MonoBehaviour
{
    [SerializeField] private float respawnDelay = 2f;
    private GameObject player;

    private static RespawnPos instance;
    public static RespawnPos Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RespawnPos>();
            }
            return instance;
        }
    }

    public void RespawnPlayer(GameObject player)
    {
        this.player = player;
        StartCoroutine(RespawnPlayer(respawnDelay));
    }

    private IEnumerator RespawnPlayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = transform.position;
        player.SetActive(true);
        Camera.main.transform.parent = player.transform;
        Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.75f, player.transform.position.z);
        player.transform.rotation = transform.rotation;
    }
}
