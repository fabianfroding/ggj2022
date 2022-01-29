using System.Collections;
using UnityEngine;

public class DarkWorldController : MonoBehaviour
{
    [SerializeField] KeyCode darkWorldSwitckKey;
    //added wait time
    [SerializeField] float waitTime = 2f;

    //Adding the animator component of the Blackout Screen
    [SerializeField] private Animator blackoutScreenAnim;

    private void Update()
    {
        if (Input.GetKeyDown(darkWorldSwitckKey))
        {
            StartCoroutine(SwitchEnvironments());
        }
    }

    private IEnumerator SwitchEnvironments()
    {
        blackoutScreenAnim.Play("CrossFadeStart");
        yield return new WaitForSeconds(waitTime);
        GrayscaleManager.Instance.ChangeToGreyscale(!GrayscaleManager.Instance.IsInGrayscaleMode());
        DarkWorldManager.Instance.ActivateDarkWorld(!DarkWorldManager.Instance.IsActive());
    }
}
