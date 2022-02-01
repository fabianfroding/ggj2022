using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class UICatStatuesNew : MonoBehaviour
{
    //[Tooltip("Generate number of UI elements automatically based on number of statues placed in ths scene.")]
    //[SerializeField] private bool countStatuesInScene = false;
    [Range(0, 9)]
    [SerializeField] private int numStatues = 3;
    [SerializeField] private GameObject uiCatDecor;
    private int maxStatues = 9;

    private static UICatStatuesNew instance;
    public static UICatStatuesNew Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UICatStatuesNew>();
            }
            return instance;
        }
    }

    [SerializeField] private GameObject[] uiCatStatueCircles;

    private void Awake()
    {
        SetActiveUI();
    }

    private void Update()
    {
        if (!EditorApplication.isPlaying)
        {
            SetActiveUI();
        }
    }

    private void SetActiveUI()
    {
        for (int i = 0; i < maxStatues; i++)
        {
            uiCatStatueCircles[i].SetActive(i < numStatues);
        }
        uiCatDecor.SetActive(numStatues > 0);
    }

    public void SetFilledCircles(int n)
    {
        for (int i = 0; i < n && i < uiCatStatueCircles.Length; i++)
        {
            if (!uiCatStatueCircles[i].GetComponent<UICatStatueCircle>().IsFilled())
            {
                uiCatStatueCircles[i].GetComponent<UICatStatueCircle>().Fill(true);
            }
        }
    }
}
