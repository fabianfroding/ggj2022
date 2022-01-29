using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    //added wait time
    [SerializeField] float waitTime = 2f;
    //Adding the animator component of the Blackout Screen
    [SerializeField] private Animator blackoutScreenAnim;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //commented the lines and added the Coroutine method
            //Camera.main.transform.parent = null;
            //gameObject.SetActive(false);
            //RespawnPos.Instance.RespawnPlayer(gameObject);
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
