using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 10f;
    public delegate void ScoreManager(int pointsOnSingleHit);
    public static event ScoreManager OnEnemyDestroyed;
    [SerializeField]
    private int pointsOnSingleHit;
    [SerializeField]
    private GameObject firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    GameObject player;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag("Enemy"))
            {
                if (hit.transform.gameObject.GetComponent<EnemySelectionStatus>().isEnemySelected == false)
                {
                    hit.transform.gameObject.GetComponent<EnemySelectionStatus>().isEnemySelected = true;
                    Vector3 targetPosition = hit.transform.position;
                    Vector3 targetDirection = new Vector3(targetPosition.x, 0f, targetPosition.z)
                        - new Vector3(player.transform.position.x, 0f, player.transform.position.z);
                    Quaternion newDirection = Quaternion.LookRotation(targetDirection);
                    player.transform.rotation = Quaternion.Slerp(player.transform.rotation, newDirection, Time.deltaTime * turnSpeed);
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                    bullet.GetComponent<Bullet>().target = hit.transform;
                }
            }
        }
    }

}
