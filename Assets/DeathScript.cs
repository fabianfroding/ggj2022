using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public static bool alive = true;
    [SerializeField]
    MouseLook mouse;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    Transform cameraTrans;


    void Start()
    {
        
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


    }
}
