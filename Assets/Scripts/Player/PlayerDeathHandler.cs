using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    PlayerMovement player;
    
    [SerializeField]
    GameObject camObject;
    [SerializeField]
    GameObject head;

    public GameObject[] Limbs;

    public CapsuleCollider capsuleColl;
    Collider[] colliders = new Collider[11];
    Rigidbody[] rb = new Rigidbody[11];
    [SerializeField]
    Animator anim;

    [SerializeField]
    GameObject graphics;

    // Start is called before the first frame update
    void Start()
    {
        capsuleColl = GetComponent<CapsuleCollider>();
        player = GetComponent<PlayerMovement>();
        graphics.SetActive(false);
        InitializeBones();
    }

    public void Gripped(bool gripped)
    {
        if(gripped)
        {
            transform.position = new Vector3(transform.position.x, 2.8f, transform.position.z);
            capsuleColl.enabled = false;
        }
    }

    public void DisconnectSkeleton(bool activate)
    {
        if(activate)
        {
            graphics.SetActive(true);
            anim.enabled = false;
            graphics.transform.parent = null;
            camObject.transform.parent = head.transform;
            camObject.transform.localPosition = new Vector3(0, 0.05814839f, 0.082057f);
            camObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            Camera.main.orthographic = false;

            EnableBones();
        }
    }

    void EnableBones()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            rb[i].useGravity = true;
            colliders[i].enabled = true;
        }
    }

    void InitializeBones()
    {
        for (int i = 0; i < Limbs.Length; i++)
        {
            colliders[i] = Limbs[i].GetComponent<Collider>();
            rb[i] = Limbs[i].GetComponent<Rigidbody>();

            rb[i].useGravity = false;
            colliders[i].enabled = false;
        }
    }
}
