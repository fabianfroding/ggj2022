using UnityEngine;

public class DarkWorldManager : MonoBehaviour
{
    [SerializeField] private GameObject darkWorldParentGO;
    [SerializeField] private GameObject lightWorldParentGO;

    private static DarkWorldManager instance;
    public static DarkWorldManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DarkWorldManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        darkWorldParentGO.SetActive(false);
        lightWorldParentGO.SetActive(true);
    }

    public bool IsActive()
    {
        return darkWorldParentGO.activeSelf;
    }

    public void ActivateDarkWorld(bool val)
    {
        darkWorldParentGO.SetActive(val);
        lightWorldParentGO.SetActive(!val);
    }
}
