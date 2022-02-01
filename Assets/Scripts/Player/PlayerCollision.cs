using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    //added wait time
    //[SerializeField] float waitTime = 2f;
    //Adding the animator component of the Blackout Screen
    [SerializeField] private Animator blackoutScreenAnim;
    [SerializeField] private GameObject playerDeathSoundPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DeathManager.Instance.alive = false;
            DeathManager.Instance.capturer = collision.gameObject;
            GameObject.Find(EditorConstants.TAG_PLAYER).GetComponent<PlayerMovement>().StopFootstepsSound();
            //StartCoroutine(transitionToGameOverScreen());
        }
    }
}
