using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private void OnEnable()
    {
        EnemyDestroyManager.OnEnemyExploded += ShootParticlesOnEnemyDestroyed;
    }
    private void OnDisable()
    {
        EnemyDestroyManager.OnEnemyExploded -= ShootParticlesOnEnemyDestroyed;
    }

    private void ShootParticlesOnEnemyDestroyed(GameObject destroyExplosion, Transform enemyTransform)
    {
        Instantiate(destroyExplosion, enemyTransform.position, enemyTransform.rotation);
    }
}
