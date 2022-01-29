using UnityEngine;

public class DarkWorldManager : MonoBehaviour
{
    [SerializeField] private GameObject darkWorldParentGO;
    [SerializeField] private GameObject lightWorldParentGO;

    [SerializeField] private AudioSource enterLightWorldSound;
    [SerializeField] private AudioSource enterDarkWorldSound;

    private static DarkWorldManager instance;

    [SerializeField]
    Skybox skyboxDark;
    [SerializeField]
    Skybox skyboxLight;
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

    private void Awake()
    {
        if (darkWorldParentGO == null)
        {
            darkWorldParentGO = GameObject.Find("DarkWorld");
        }
        
        if (lightWorldParentGO == null)
        {
            lightWorldParentGO = GameObject.Find("LightWorld");
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

        if (val)
        {
            RenderSettings.skybox = mat2;
            enterDarkWorldSound.Play();
            AmbienceSound.Instance.PlayDarkWorldAmbience();
        }
        else
        {
            RenderSettings.skybox = mat2;
            enterLightWorldSound.Play();
            AmbienceSound.Instance.PlayLightWorldAmbience();
        }
    }
}
