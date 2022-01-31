using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject darkWorldManagerPrefab;
    [SerializeField] private GameObject musicManagerPrefab;
    [SerializeField] private GameObject darkWorldTransitionUIPrefab;
    [SerializeField] private GameObject deathManagerPrefab;

    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        InitializeManagers();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(EditorConstants.SCENE_NAME_MAIN_MENU);
        }
    }

    public void InitializeManagers()
    {
        // Cat statue mananager
        GameObject g = new GameObject();
        g.transform.parent = transform;
        g.AddComponent<CatStatueManager>();
        g.name = "CatStatueManager";

        // Dark world manager
        Instantiate(darkWorldManagerPrefab, transform);

        // Grayscale manager
        g = new GameObject();
        g.transform.parent = transform;
        g.AddComponent<GrayscaleManager>();
        g.name = "GrayscaleManager";

        // Music manager
        Instantiate(musicManagerPrefab, transform);

        // Dark world transition UI
        Instantiate(darkWorldTransitionUIPrefab, transform);

        // Death manager
        Instantiate(deathManagerPrefab, transform);
    }
}
