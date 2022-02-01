using UnityEngine;

public class UICatStatueCircle : MonoBehaviour
{
    [SerializeField] private GameObject fill;

    private void Awake()
    {
        fill.SetActive(false);
    }

    public bool IsFilled()
    {
        return fill.activeSelf;
    }

    public void Fill(bool val)
    {
        fill.SetActive(val);
    }
}
