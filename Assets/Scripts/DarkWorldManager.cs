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
    bool LevelDesignMap;
    Light dirLight;


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

        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
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
            AmbienceSound.Instance.StopAmbience();

            if(LevelDesignMap)
            {
                dirLight.color = new Color(0.2f, 0.2f, 0.2f, 1);
                dirLight.intensity = 0.1f;
            }
        }
        else
        {
            RenderSettings.skybox = skyboxLight;
            enterLightWorldSound.Play();
            AmbienceSound.Instance.PlayLightWorldAmbience();

            if (LevelDesignMap)
            {
                dirLight.color = Color.white;
                dirLight.intensity = 1f;

            }
        }
    }

    void InitializeStart()
    {
        RenderSettings.skybox = skyboxLight;
        enterLightWorldSound.Play();
        AmbienceSound.Instance.PlayLightWorldAmbience();
    }
}
