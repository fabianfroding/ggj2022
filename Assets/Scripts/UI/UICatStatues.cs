using UnityEngine;
using UnityEngine.UI;

public class UICatStatues : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private static UICatStatues instance;
    public static UICatStatues Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UICatStatues>();
            }
            return instance;
        }
    }


    public void SetCollected(int collectedCats)
    {
        slider.value = collectedCats; 
    }
}
