using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 10f;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject firePoint;
    public Camera arCam;
    RaycastHit hit;
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            var ray = arCam.ViewportPointToRay(new Vector3(0.5f,0.5f));
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.transform.CompareTag("Enemy"))
                {
                    if(hit.transform.gameObject.GetComponent<EnemySelectionStatus>().isEnemySelected == false)
                    {
                        hit.transform.gameObject.GetComponent<EnemySelectionStatus>().isEnemySelected = true;
                        Vector3 targetPosition = hit.transform.position;
                        Vector3 targetDirection = new Vector3(targetPosition.x, 0f, targetPosition.z)  
                            - new Vector3(transform.position.x, 0f, transform.position.z);
                        Quaternion newDirection = Quaternion.LookRotation(targetDirection);
                        transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
                        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                        bullet.GetComponent<Bullet>().target = hit.transform;
                    }
                    
                         
                }
            }
        }
    }
}
