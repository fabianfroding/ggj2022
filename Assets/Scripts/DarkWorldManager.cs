using UnityEngine;

public class DarkWorldManager : MonoBehaviour
{
    [SerializeField] private GameObject darkWorldParentGO;
    [SerializeField] private GameObject lightWorldParentGO;

    [SerializeField] private AudioSource enterLightWorldSound;
    [SerializeField] private AudioSource enterDarkWorldSound;

    private static DarkWorldManager instance;

    [SerializeField]
    Material skyboxDark;
    [SerializeField]
    Material skyboxLight;

    [SerializeField]
    float test;
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
        InitializeStart();
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
            RenderSettings.skybox = skyboxDark;
            enterDarkWorldSound.Play();
            AmbienceSound.Instance.PlayDarkWorldAmbience();
        }
        else
        {
            RenderSettings.skybox = skyboxLight;
            enterLightWorldSound.Play();
            AmbienceSound.Instance.PlayLightWorldAmbience();
        }
    }

    void InitializeStart()
    {
        RenderSettings.skybox = skyboxLight;
        enterLightWorldSound.Play();
        AmbienceSound.Instance.PlayLightWorldAmbience();
    }
}
