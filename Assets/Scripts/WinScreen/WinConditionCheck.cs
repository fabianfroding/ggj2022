using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinConditionCheck : MonoBehaviour
{
    [SerializeField] private CatStatueManager clm;
    [SerializeField] private int tot_collectables;
    [SerializeField] private Animator blackoutScreenAnim;
    [SerializeField] private float waitTime = 2f;
    // Start is called before the first frame update

    private void Start()
    {
        blackoutScreenAnim = GameObject.Find("CrossFade").GetComponent<Animator>();
        clm = FindObjectOfType<CatStatueManager>();
    }


    // Update is called once per frame
    void Update()
    {
        checkCollectedCatCount();
    }

    private void checkCollectedCatCount()
    {
        if(clm.collectedStatues == tot_collectables )
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
        SceneManager.LoadScene(sceneName: EditorConstants.SCENE_NAME_LEVEL_COMPLETE);
    }
}
