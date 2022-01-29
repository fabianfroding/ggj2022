using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatueScript : MonoBehaviour
{
    public Slider slider;

    private static StatueScript instance;
    public static StatueScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StatueScript>();
            }
            return instance;
        }
    }


    public void SetCollected(int collectedCats)
    {
        slider.value = collectedCats; 
    }
}
