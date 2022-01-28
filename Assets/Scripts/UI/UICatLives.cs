using TMPro;
using UnityEngine;

public class UICatLives : MonoBehaviour
{
    private static UICatLives instance;
    public static UICatLives Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UICatLives>();
            }
            return instance;
        }
    }

    public void UpdateUI(int collectedCats, int availableCats)
    {
        GetComponent<TextMeshProUGUI>().text = "Cats collected: " + collectedCats + "/" + availableCats;
    }
}
