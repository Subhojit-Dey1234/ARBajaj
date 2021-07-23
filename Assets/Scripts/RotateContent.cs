using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContent : MonoBehaviour
{
    Vector3 targetVal = Vector3.zero;
    public GameObject Content;
    void Update()
    {
        Content.transform.LookAt(Camera.main.transform);
        targetVal = Content.transform.localEulerAngles;
        targetVal.x = 0;
        targetVal.z = 0;
        transform.localEulerAngles = targetVal;
    }
}
