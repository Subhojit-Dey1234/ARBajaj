using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    // Start is called before the first frame update

    private Info info;

    void Start()
    {
        info = FindObjectOfType<Info>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out RaycastHit hit )){
            GameObject go = hit.transform.gameObject;
            Debug.Log(go.tag);
            if(go.tag == "Purifier"){
               go.GetComponent<Info>().OpenInfo();
            }
            else
            {
                info.ClosedInfo();
            }
        }
    }
}
