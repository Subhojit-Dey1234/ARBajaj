using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform SectionInfo;

    Vector3 desiredScale = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale,desiredScale,Time.deltaTime * 6f);
    }

    public void OpenInfo(){
        desiredScale = Vector3.one;
    }
    public void ClosedInfo(){
        desiredScale = Vector3.zero;
    }
}
