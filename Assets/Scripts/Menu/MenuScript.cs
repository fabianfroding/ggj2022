using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: EditorConstants.SCENE_NAME_SAMPLE_LEVEL);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
