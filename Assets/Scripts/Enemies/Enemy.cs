using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject appearSFX;

    private void OnEnable()
    {
        GameObject sfx = Instantiate(appearSFX, transform);
        sfx.transform.parent = null; // Detach from enemy game object so the SFX doesnt follow the enemy.
        Destroy(sfx, sfx.GetComponent<ParticleSystem>().main.duration); // Destroy sfx after its done.
    }
}
