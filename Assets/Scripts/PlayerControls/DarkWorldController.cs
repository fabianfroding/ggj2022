using UnityEngine;

public class DarkWorldController : MonoBehaviour
{
    [SerializeField] KeyCode darkWorldSwitckKey;
    [SerializeField] GameObject darkWorldParentGO;

    private void Update()
    {
        if (Input.GetKeyDown(darkWorldSwitckKey))
        {
            GrayscaleManager.Instance.ChangeToGreyscale(!GrayscaleManager.Instance.IsInGrayscaleMode());
            DarkWorldManager.Instance.ActivateDarkWorld(!DarkWorldManager.Instance.IsActive());
        }
    }
}
