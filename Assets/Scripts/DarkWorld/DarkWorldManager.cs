using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWorldManager : MonoBehaviour
{
    public bool IsActive { get; private set; }

    [SerializeField] private GameObject enterLightWorldSoundPrefab;
    [SerializeField] private GameObject enterDarkWorldSoundPrefab;
    [SerializeField] private Material skyboxDark;
    [SerializeField] private Material skyboxLight;
    [SerializeField] KeyCode darkWorldTransitionKey;
    [SerializeField] float transitionDelay = 2f;

    public List<GameObject> darkWorldObjects { get; private set; }
    private Light dirLight;
    private bool isTransitioning = false;

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

    #region Unity Callback Functions
    private void Awake()
    {
        IsActive = false;
        darkWorldObjects = GetActiveDarkWorldObjects();
    }

    private void Start()
    {
        EnableDarkWorldObjects(false);

        InitializeStart();
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>(); // TODO: Remove string literal.
    }

    private void Update()
    {
        HandleInput();
    }
    #endregion

    private void HandleInput()
    {
        if (Input.GetKeyDown(darkWorldTransitionKey) && !isTransitioning)
        {
            StartCoroutine(SwitchEnvironments(transitionDelay));
        }
    }

    private IEnumerator SwitchEnvironments(float delay)
    {
        isTransitioning = true;
        GameObject.Find(EditorConstants.GAME_OBJECT_NAME_CROSS_FADE).GetComponent<Animator>().Play(AnimationConstants.ANIM_CROSS_FADE_START);
        yield return new WaitForSeconds(delay);
        GrayscaleManager.Instance.ChangeToGreyscale(!GrayscaleManager.Instance.IsInGrayscaleMode());
        ActivateDarkWorld(!IsActive);
        SwitchMusic();
        isTransitioning = false;
    }

    private void SwitchMusic()
    {
        if (!DeathManager.Instance.executed)
        {
            if (!IsActive)
            {
                MusicManager.Instance.PlayLightWorldMusic();
            }
            else
            {
                MusicManager.Instance.PlayDarkWorldMusic();
            }
        }
    }

    public void ActivateDarkWorld(bool val)
    {
        IsActive = val;
        EnableDarkWorldObjects(val);
        SetWorldEnvSettings(val);
    }

    private void SetWorldEnvSettings(bool darkWorld)
    {
        RenderSettings.skybox = darkWorld ? skyboxDark : skyboxLight;
        if (dirLight != null)
        {
            dirLight.color = darkWorld ? new Color(0.2f, 0.2f, 0.2f, 1) : Color.white;
            dirLight.intensity = darkWorld ? 0.1f : 1f;
        }

        if (darkWorld)
        {
            Instantiate(enterDarkWorldSoundPrefab, Camera.main.transform);
            AmbienceSound.Instance.StopAmbience();
        }
        else
        {
            Instantiate(enterLightWorldSoundPrefab, Camera.main.transform);
            AmbienceSound.Instance.PlayLightWorldAmbience();
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
        AmbienceSound.Instance.PlayLightWorldAmbience();
    }
}
