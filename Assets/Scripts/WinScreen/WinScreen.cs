using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private AudioSource winSound;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        GetComponent<AudioSource>().Play();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");

    }
}
