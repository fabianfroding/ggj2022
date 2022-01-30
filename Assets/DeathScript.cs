using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public bool alive = true;
    GameObject playerObject;
    GameObject mouseObject;
    PlayerMovement player;
    PlayerDeathHandler playerDeath;
    MouseLook mouseCam;

    [SerializeField]
    GameObject claw;

    public GameObject capturer;
    EnemyAI captureScript;
    Camera cam;

    float timer = 0;
    float pickUpInterval = 2f;

    [SerializeField]
    float dropInterval = 5;
    [SerializeField]
    float scareInterval = 3;

    float gameOverInterval = 7;

    [SerializeField]
    GameObject playerDeathSoundPrefab;

    //added wait time
    [SerializeField] float waitTime = 2f;
    //Adding the animator component of the Blackout Screen
    [SerializeField] private Animator blackoutScreenAnim;

    void Start()
    {
        mouseObject = GameObject.Find("Main Camera");
        playerObject = GameObject.Find("Player");
        if(claw == null)
            claw = GameObject.Find("The Paw!");
        player = playerObject.GetComponent<PlayerMovement>();
        playerDeath = playerObject.GetComponent<PlayerDeathHandler>();

        mouseCam = mouseObject.GetComponent<MouseLook>();

        claw.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AliveBool(alive);

        if(Input.GetKeyDown(KeyCode.H))
        {
            alive = false;
        }
    }

    void AliveBool(bool alive)
    {
        player.enabled = alive;
        mouseCam.enabled = alive;
        //claw.SetActive(!alive);
        if (!alive)
        {
            DeathAnim();
        }
    }

    void DeathAnim()
    {
        timer += Time.deltaTime;


        captureScript = capturer.GetComponent<EnemyAI>();

        if(timer <= scareInterval)
            claw.SetActive(true);
        else
            claw.SetActive(false);

        if (timer >= pickUpInterval)
        {
            if(timer >= scareInterval && timer <= dropInterval)
            {
                ScareCam();
            }
            else if(timer > dropInterval && timer < gameOverInterval)
            {
                NormalCam();

                playerDeath.DisconnectSkeleton(true);
            }
            else if(timer > gameOverInterval)
            {
                StartCoroutine(transitionToGameOverScreen());
            }
            else
            {
                NormalCam();
            }
        }
        else if(timer >= 5)
        {
            captureScript.anim.SetBool("KillingDone", true);
        }

        if(timer <= 5)
        {
            playerDeath.Gripped(true);
        }
        else
            playerDeath.Gripped(false);
    }

    void ScareCam()
    {
        mouseObject.transform.LookAt(captureScript.deathTarget.transform);
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = Random.Range(0.5f, 0.8f);
        captureScript.ScareEvent(true);
        if (GameObject.Find("SND_Player_Death(Clone)") == null)
            GameObject.Instantiate(playerDeathSoundPrefab);
    }

    void NormalCam()
    {
        captureScript.ScareEvent(false);
    }

    private IEnumerator transitionToGameOverScreen()
    {
        blackoutScreenAnim.Play("CrossFadeStart");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName: "Game Over");
    }
}
