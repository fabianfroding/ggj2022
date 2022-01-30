using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinConditionCheck : MonoBehaviour
{
    [SerializeField] private CatLifeManager clm;
    [SerializeField] private int tot_collectables;
    [SerializeField] private Animator blackoutScreenAnim;
    [SerializeField] private float waitTime = 2f;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        checkCollectedCatCount();
    }

    private void checkCollectedCatCount()
    {
        if(clm.collectedCats == tot_collectables )
        {
            tot_collectables = 0;
            StartCoroutine(jumpToWinScene());
        }
    }

    IEnumerator jumpToWinScene()
    {
        blackoutScreenAnim.Play("CrossFadeStart");
        yield return new WaitForSeconds(waitTime);
        //load winScreen
        SceneManager.LoadScene(sceneName: "WinScene");
    }
}
