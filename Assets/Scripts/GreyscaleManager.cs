using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyscaleManager : MonoBehaviour
{
    private static GreyscaleManager instance;
    public static GreyscaleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GreyscaleManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ChangeToGreyscale(bool val)
    {
        if (val)
        {
            // TODO: Find all children of greyscale GO and change mat to greyscale
        }
        else
        {
            
        }
    }
}
