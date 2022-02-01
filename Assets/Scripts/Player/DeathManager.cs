using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public bool alive = true;
    public bool executed;
    public GameObject capturer;

    GameObject playerObject;
    GameObject mouseObject;
    PlayerMovement player;
    PlayerDeathHandler playerDeath;
    MouseLook mouseCam;
    EnemyAI captureScript;
    Camera cam;
    float timer = 0;
    float pickUpInterval = 2f;
    float gameOverInterval = 9;

    [SerializeField] GameObject claw;
    [SerializeField] float dropInterval = 5;
    [SerializeField] float scareInterval = 3;
    [SerializeField] GameObject playerDeathSoundPrefab;
    [SerializeField] float waitTime = 2f;

    private static DeathManager instance;
    public static DeathManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DeathManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        mouseObject = Camera.main.gameObject;
        playerObject = GameObject.Find(EditorConstants.TAG_PLAYER);
        if(claw == null)
            claw = GameObject.Find(EditorConstants.GAME_OBJECT_NAME_CAMERA_PAW);
        player = playerObject.GetComponent<PlayerMovement>();
        playerDeath = playerObject.GetComponent<PlayerDeathHandler>();

        mouseCam = mouseObject.GetComponent<MouseLook>();

        if (claw != null) claw.SetActive(false);
    }

    void Update()
    {
        AliveBool(alive);
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
                StartCoroutine(TransitionToGameOverScreen());
            }
            else
            {
                NormalCam();
            }
        }
        else if(timer >= 5)
        {
            captureScript.anim.SetBool(AnimationConstants.ANIM_KILLING_DONE, true);
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

        if (!executed)
            Instantiate(playerDeathSoundPrefab);

        executed = true;
    }

    void NormalCam()
    {
        captureScript.ScareEvent(false);
    }

    private IEnumerator TransitionToGameOverScreen()
    {
        GameObject.Find(EditorConstants.GAME_OBJECT_NAME_CROSS_FADE).GetComponent<Animator>().Play(AnimationConstants.ANIM_CROSS_FADE_START);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(EditorConstants.SCENE_NAME_GAME_OVER);
    }
}
