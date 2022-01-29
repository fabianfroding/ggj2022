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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(transitionToGameOverScreen());
        }
    }

    private IEnumerator transitionToGameOverScreen()
    {
        blackoutScreenAnim.Play("CrossFadeStart");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName: "Game Over");
    }
}
