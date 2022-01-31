using System.Collections;
using UnityEngine;

// TODO: Merge this class into DarkWorldManager
public class DarkWorldController : MonoBehaviour
{
    [SerializeField] KeyCode darkWorldSwitckKey;
    [SerializeField] float waitTime = 2f;

    private void Update()
    {
        if(DeathManager.Instance.alive)
        {
            if (Input.GetKeyDown(darkWorldSwitckKey))
            {
                StartCoroutine(SwitchEnvironments());
            }
        }


        if(DeathManager.Instance.executed)
        {
            MusicManager.Instance.PauseAllMusic();
        }
    }

    private IEnumerator SwitchEnvironments()
    {
        GameObject.Find(EditorConstants.GAME_OBJECT_NAME_CROSS_FADE).GetComponent<Animator>().Play("CrossFadeStart"); // TODO: Remove string lit.
        yield return new WaitForSeconds(waitTime);
        GrayscaleManager.Instance.ChangeToGreyscale(!GrayscaleManager.Instance.IsInGrayscaleMode());
        DarkWorldManager.Instance.ActivateDarkWorld(!DarkWorldManager.Instance.IsActive);
        SwitchMusic();
    }

    private void SwitchMusic()
    {
        if(!DeathManager.Instance.executed)
        {
            if (!DarkWorldManager.Instance.IsActive)
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
