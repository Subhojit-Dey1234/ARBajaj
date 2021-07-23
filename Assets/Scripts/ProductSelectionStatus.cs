using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSelectionStatus : MonoBehaviour
{
    private void Awake()
    {
        Camera.main.GetComponent<ProductInfoDisplayManager>().productSelectionStatusList.Add(gameObject);
    }
}
