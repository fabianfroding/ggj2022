using UnityEngine;

public class CatLifeManager : MonoBehaviour
{
    public int collectedCats { get; private set; }
    public int collectableCats { get; private set; }

    private static CatLifeManager instance;
    public static CatLifeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CatLifeManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        this.collectableCats = CountCollectableCats();
    }

    public void AddCollectedCat()
    {
        collectedCats++;
        //UICatLives.Instance.UpdateUI(collectedCats, this.collectableCats);
        StatueScript.Instance.SetCollected(collectedCats);
    }

    private int CountCollectableCats()
    {
        CatLifeCollectible[] collectableCats = FindObjectsOfType<CatLifeCollectible>();
        return collectableCats.Length;
    }
}
