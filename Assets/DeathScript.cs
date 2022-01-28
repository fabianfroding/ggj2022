using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public bool alive = true;
    MouseLook mouse;
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
        mouse = mouseObject.GetComponent<MouseLook>();
        player = playerObject.GetComponent<PlayerMovement>();
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
        mouse.enabled = alive;
        player.enabled = alive;
        claw.SetActive(!alive);
        if (!alive)
        {
            DeathAnim();
        }
    }

    void DeathAnim()
    {
        claw.SetActive(true);
        Vector3 playerPos = playerObject.transform.position;
        timer += Time.deltaTime;

        playerObject.transform.position = new Vector3(playerPos.x, 2.8f, playerPos.z);

        if (timer >= pickUpInterval)
        {
            //playerObject.transform.position = new Vector3(playerPos.x, 2.8f, playerPos.z);
            playerObject.transform.rotation = Quaternion.RotateTowards(playerObject.transform.localRotation, Quaternion.Inverse(capturer.transform.rotation), 200 * Time.deltaTime);
            playerObject.transform.LookAt(capturer.transform);
        }
        else if(timer >= 5)
        {
            captureScript = capturer.GetComponent<EnemyAI>();
            captureScript.anim.SetBool("KillingDone", true);
        }
    }
}
