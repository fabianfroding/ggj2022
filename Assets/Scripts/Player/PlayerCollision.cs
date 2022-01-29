using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    //added wait time
    [SerializeField] float waitTime = 2f;
    //Adding the animator component of the Blackout Screen
    [SerializeField] private Animator blackoutScreenAnim;
    [SerializeField] private GameObject playerDeathSoundPrefab;

    DeathScript deathScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            deathScript = GameObject.Find("DeathManager").GetComponent<DeathScript>();
            deathScript.alive = false;
            deathScript.capturer = collision.gameObject;
            //StartCoroutine(transitionToGameOverScreen());
        }
    }
}
