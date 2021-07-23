using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    [SerializeField]
    private float bulletSpeed = 5f;
    [SerializeField]
    private float bulletDestroyTime = 1f;
    //void Start()
    //{
    //    StartCoroutine(DestroyBullet(bulletDestroyTime));
    //}
    //IEnumerator DestroyBullet(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    Destroy(gameObject);
    //}
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        gameObject.transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, bulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
