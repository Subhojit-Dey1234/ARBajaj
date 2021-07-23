using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductRotationManager : MonoBehaviour
{
    Vector3 targetVal = Vector3.zero;
    [SerializeField]
    float turnSpeed = 5f;
    void Update()
    {
        Debug.Log("Rotation");
        gameObject.transform.LookAt(Camera.main.transform);
        targetVal = gameObject.transform.localEulerAngles;
        targetVal.x = 0;
        targetVal.z = 0;
        transform.localEulerAngles = targetVal;
       /* float relativex = Camera.main.transform.position.x - gameObject.transform.position.x;
        float relativez = Camera.main.transform.position.z - gameObject.transform.position.z;
        Vector3 relativePos = new Vector3(relativex, 0, relativez);
        Quaternion newDirection = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);*/
        
    }
}
