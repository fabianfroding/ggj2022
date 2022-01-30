using System.Collections;
using UnityEngine;

public class DarkWorldController : MonoBehaviour
{
    [SerializeField] KeyCode darkWorldSwitckKey;
    //added wait time
    [SerializeField] float waitTime = 2f;

    //Adding the animator component of the Blackout Screen
    [SerializeField] private Animator blackoutScreenAnim;

    DeathScript death;

    private void Start()
    {
        death = GameObject.Find("DeathManager").GetComponent<DeathScript>();
    }

    private void Update()
    {
        if(death.alive)
        {
            if (Input.GetKeyDown(darkWorldSwitckKey))
            {
                StartCoroutine(SwitchEnvironments());
            }
        }


        if(death.executed)
        {
            MusicManager.Instance.PauseAllMusic();
        }
    }

    private IEnumerator SwitchEnvironments()
    {
        blackoutScreenAnim.Play("CrossFadeStart");
        yield return new WaitForSeconds(waitTime);
        GrayscaleManager.Instance.ChangeToGreyscale(!GrayscaleManager.Instance.IsInGrayscaleMode());
        DarkWorldManager.Instance.ActivateDarkWorld(!DarkWorldManager.Instance.IsActive());
        Debug.Log("SwitchMusic");
        SwitchMusic();
    }

    private void SwitchMusic()
    {
        if(!death.executed)
        {
            if (!DarkWorldManager.Instance.IsActive())
            {
                MusicManager.Instance.PlayLightWorldMusic();
            }
            else
            {
                MusicManager.Instance.PlayDarkWorldMusic();
            }
        }
    }
}
