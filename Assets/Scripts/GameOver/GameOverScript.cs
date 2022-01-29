using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private Animator transitionAnim;
    // Start is called before the first frame update

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void RestartGame()
    {
        //loads the Test Scene
        SceneManager.LoadScene(sceneName: "Sample-RivinduTest");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");

    }

    //private IEnumerator transitionToMainMenu()
    //{
    //    transitionAnim.Play("CrossFadeStart");
    //    yield return new WaitForSeconds(waitTime);
    //    SceneManager.LoadScene(sceneName: "MainMenu");
    //}
}