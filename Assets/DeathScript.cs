using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public bool alive = true;
    MouseLook camera;
    GameObject playerObject;
    GameObject mouseObject;
    PlayerMovement player;

    [SerializeField]
    GameObject claw;

    public GameObject capturer;
    EnemyAI captureScript;

    float timer = 0;
    float pickUpInterval = 2f;


    void Start()
    {
        mouseObject = GameObject.Find("Main Camera");
        playerObject = GameObject.Find("Player");
        camera = mouseObject.GetComponent<MouseLook>();
        player = playerObject.GetComponent<PlayerMovement>();

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
        camera.enabled = alive;
        player.enabled = alive;
        //claw.SetActive(!alive);
        if (!alive)
        {
            DeathAnim();
        }
    }

    void DeathAnim()
    {
        Vector3 playerPos = playerObject.transform.position;
        timer += Time.deltaTime;

        playerObject.transform.position = new Vector3(playerPos.x, 2.8f, playerPos.z);

        captureScript = capturer.GetComponent<EnemyAI>();

        if(timer <= pickUpInterval)
            claw.SetActive(true);
        else
            claw.SetActive(false);

        if (timer >= pickUpInterval)
        {
            mouseObject.transform.LookAt(captureScript.deathTarget.transform);
            if(timer >= 4)
            {
                Camera.main.orthographic = true;
                Camera.main.orthographicSize = Random.Range(0.5f, 0.8f);
                captureScript.ScareEvent();
            }
        }
        else if(timer >= 5)
        {
            captureScript.anim.SetBool("KillingDone", true);
        }
    }
}
