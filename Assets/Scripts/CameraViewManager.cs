using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraViewManager : MonoBehaviour
{
    List<ProductInfoManager> infos = new List<ProductInfoManager>();
    
    void Start()
    {
        infos = FindObjectsOfType<ProductInfoManager>().ToList();
    }
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.transform.gameObject;
            Debug.Log($"Ray hit an object with tag:{go.tag}");
            if (go.CompareTag("Product"))
            {
                foreach(ProductInfoManager info in infos)
                {
                    if(go.GetComponent<ProductInfoManager>() == info)
                    {
                        info.OpenInfo();
                    }
                    else
                    {
                        info.ClosedInfo();
                    }
                }
               // foreach(GameObject productObject in         )
                //{
                    /*if(productObject.GetComponent<ProductSelectionStatus>().isSelected == true)
                    {
                        productObject.GetComponent<ProductSelectionStatus>().isSelected = false;
                        productObject.GetComponent<ProductInfoManager>().ClosedInfo();
                    }
                    else if (productObject.GetComponent<ProductSelectionStatus>().isSelected == false && productObject.name == go.name)
                    {
                        productObject.GetComponent<ProductSelectionStatus>().isSelected = true;
                        productObject.GetComponent<ProductInfoManager>().OpenInfo();
                    }*/
                //}
                //go.GetComponent<ProductInfoManager>().OpenInfo();
                //go.GetComponent<ProductSelectionStatus>().isSelected = true;
            }
           // else
            //{
           //     info.ClosedInfo();
           // }
        }

        else
        {
            ClosedAll();
        }
    }

    private void ClosedAll()
    {
      foreach(ProductInfoManager info in infos)
        {
            info.ClosedInfo();
        }
    }
}
