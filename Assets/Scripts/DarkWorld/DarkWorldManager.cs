using System.Collections.Generic;
using UnityEngine;

public class DarkWorldManager : MonoBehaviour
{
    public bool IsActive { get; private set; }

    [SerializeField] private AudioSource enterLightWorldSound;
    [SerializeField] private AudioSource enterDarkWorldSound;
    [SerializeField] private Material skyboxDark;
    [SerializeField] private Material skyboxLight;

    public List<GameObject> darkWorldObjects { get; private set; }
    private Light dirLight;

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

    private void Awake()
    {
        IsActive = false;
        darkWorldObjects = GetActiveDarkWorldObjects();
    }

    private void Start()
    {
        EnableDarkWorldObjects(false);

        InitializeStart();
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    public void ActivateDarkWorld(bool val)
    {
        IsActive = val;
        EnableDarkWorldObjects(val);

        if (val)
        {
            RenderSettings.skybox = skyboxDark;
            transform.position = GameObject.Find("Player").transform.position; // To allow hearing the sound.
            enterDarkWorldSound.Play();
            AmbienceSound.Instance.StopAmbience();

            if(dirLight != null)
            {
                dirLight.color = new Color(0.2f, 0.2f, 0.2f, 1);
                dirLight.intensity = 0.1f;
            }
        }
        else
        {
            RenderSettings.skybox = skyboxLight;
            transform.position = GameObject.Find("Player").transform.position;
            enterLightWorldSound.Play();
            AmbienceSound.Instance.PlayLightWorldAmbience();

            if (dirLight != null)
            {
                dirLight.color = Color.white;
                dirLight.intensity = 1f;
            }
        }
    }

    private List<GameObject> GetActiveDarkWorldObjects()
    {
        List<GameObject> objects = new List<GameObject>();
        GameObject[] darkWorldObjects = FindObjectsOfType<GameObject>();
        for (int i = 0; i < darkWorldObjects.Length; i++)
        {
            if (darkWorldObjects[i].layer == LayerMask.NameToLayer(EditorConstants.LAYER_DARK_WORLD))
            {
                objects.Add(darkWorldObjects[i]);
            }
        }
        return objects;
    }

    private void EnableDarkWorldObjects(bool val)
    {
        for (int i = 0; i < darkWorldObjects.Count; i++)
        {
            if (darkWorldObjects[i] != null)
            {
                darkWorldObjects[i].SetActive(val);
            }
        }
    }

    void InitializeStart()
    {
        RenderSettings.skybox = skyboxLight;
        //enterLightWorldSound.Play();
        AmbienceSound.Instance.PlayLightWorldAmbience();
    }
}
