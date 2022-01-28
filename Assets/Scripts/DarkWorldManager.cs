using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWorldManager : MonoBehaviour
{
    [SerializeField] private GameObject darkWorldParentGO;


    private static DarkWorldManager instance;
    public static DarkWorldManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DarkWorldManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        darkWorldParentGO.SetActive(false);
    }

    public bool IsActive()
    {
        return darkWorldParentGO.activeSelf;
    }

    public void ActivateDarkWorld(bool val)
    {
        darkWorldParentGO.SetActive(val);  
    }
}
