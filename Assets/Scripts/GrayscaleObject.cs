using UnityEngine;

public class GrayscaleObject : MonoBehaviour
{
    [SerializeField] private Material grayscaleMat;
    private Material defaultMat;

    private void Awake()
    {
        defaultMat = GetComponent<Renderer>().material;
    }

    public void EnableGrayscale(bool val)
    {
        GetComponent<Renderer>().material = val ? grayscaleMat : defaultMat;
    }
}
