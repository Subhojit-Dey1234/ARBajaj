using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyManager : MonoBehaviour
{
    public delegate void EnemyExplosionManagr(GameObject destroyExplosion, Transform enemyTransform);
    public static event EnemyExplosionManagr OnEnemyExploded;
    public delegate void ScoreManager(int pointsOnSingleHit);
    public static event ScoreManager OnEnemyDestroyed;
    [SerializeField]
    private GameObject destroyExplosion;
    [SerializeField]
    private int pointsOnEnemyDestroy = 1;
    private void OnDestroy()
    {
        Debug.Log("Enemy Destroyed");
        string name = gameObject.name;
        if(name.Contains("Enemy1"))
        {
            AudioManager.Instance.PlaySound("Die_Enemy1");
        }
        else if (name.Contains("Enemy2"))
        {
            AudioManager.Instance.PlaySound("Die_Enemy2");
        }
        else if (name.Contains("Enemy3"))
        {
            AudioManager.Instance.PlaySound("Die_Enemy3");
        }
        OnEnemyExploded?.Invoke(destroyExplosion, transform);
        OnEnemyDestroyed?.Invoke(pointsOnEnemyDestroy);
        
    }
}
