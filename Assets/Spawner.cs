using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 objectPosition = default;
    [SerializeField]
    private GameObject[] enemyList;
    [SerializeField]
    private GameObject dustParticles;
    [SerializeField]
    private float spawnRadius = 4f;
    [SerializeField]
    private int numberOfEnemies = 50;

    
    private void Awake()
    {
        objectPosition = new Vector3(0f,0f,0f);
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 point = (UnityEngine.Random.insideUnitSphere * spawnRadius) + objectPosition;
            while (point.y < objectPosition.y)
            {
                point = (UnityEngine.Random.insideUnitSphere * spawnRadius) + objectPosition;
            }
            Vector3 relativePos = objectPosition - point;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            Instantiate(enemyList[UnityEngine.Random.Range(0, 3)], point, rotation);
            
        }
        Instantiate(dustParticles, objectPosition, Quaternion.identity);
    }
}
