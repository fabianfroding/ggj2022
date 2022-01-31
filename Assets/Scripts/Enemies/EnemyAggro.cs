using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField] private GameObject enemyAggroSoundPrefab;

    public void PlayEnemyAggroSound()
    {
        Instantiate(enemyAggroSoundPrefab, GameObject.Find("Player").transform);
    }
}
