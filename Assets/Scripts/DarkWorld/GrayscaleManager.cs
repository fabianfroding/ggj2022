using UnityEngine;

public class GrayscaleManager : MonoBehaviour
{
    private bool grayscaleMode = false;

    private static GrayscaleManager instance;
    public static GrayscaleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GrayscaleManager>();
            }
            return instance;
        }
    }

    public bool IsInGrayscaleMode()
    {
        return grayscaleMode;
    }

    public void ChangeToGreyscale(bool val)
    {
        GrayscaleObject[] grayscaleObjects = FindObjectsOfType<GrayscaleObject>();
        for (int i = 0; i < grayscaleObjects.Length; i++)
        {
            grayscaleObjects[i].EnableGrayscale(val);
        }
        grayscaleMode = val;
    }
}
