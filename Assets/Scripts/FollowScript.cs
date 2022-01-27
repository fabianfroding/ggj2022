using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Created for the purpose of following an object. 
//IN this situation it's first created to have the VFX follow the player rather than have it covering the whole sky

public class FollowScript : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    Vector3 pos;

    void Start()
    {
        if(target == null)
        {
            target = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.position = pos;
    }
}
