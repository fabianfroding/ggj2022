using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if (GetComponent<AudioSource>() != null) GetComponent<AudioSource>().Play();
        StartCoroutine(ReenableCursor());
        Cursor.visible = true;
    }

    private IEnumerator ReenableCursor()
    {
        yield return new WaitForSeconds(1f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName: EditorConstants.SCENE_NAME_MAIN_MENU);

    }
}
