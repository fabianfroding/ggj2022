using UnityEngine;

public class CatStatueManager : MonoBehaviour
{
    public int collectedStatues { get; private set; }
    public int sceneStatues { get; private set; }

    private static CatStatueManager instance;
    public static CatStatueManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CatStatueManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        collectedStatues = 0;
        sceneStatues = CountStatuesInScene();
    }

    public void AddStatue()
    {
        collectedStatues++;
        UICatStatuesNew.Instance.SetFilledCircles(collectedStatues);
    }

    private int CountStatuesInScene()
    {
        CatStatue[] collectableCats = FindObjectsOfType<CatStatue>();
        return collectableCats.Length;
    }
}
