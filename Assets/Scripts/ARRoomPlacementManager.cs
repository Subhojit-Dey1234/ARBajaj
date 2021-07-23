using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ARRoomPlacementManager : MonoBehaviour
{
    public delegate void ObjectSpawnManager(Vector3 spawnPosition);
    public static event ObjectSpawnManager OnObjectSpawned;
    [SerializeField]
    private GameObject roomPrefab;
    [SerializeField]
    private Camera arCam;
    ARPlaneManager aRPlaneManager;
    private Vector2 touchPosition = default;
    private ARRaycastManager aRRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool objectIsSpawned = false;
    [SerializeField]
    private GameObject planeDetectionPanel;

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        if(aRPlaneManager.trackables == null)
        {
            planeDetectionPanel.SetActive(true);
            Debug.Log("Wait while we are detecting the planes. Point your camera towards your floor, and hold it stable");
            return;
        }
        planeDetectionPanel.SetActive(false);
        if (Input.touchCount == 0)
            return;
        RaycastHit hit;
        Ray ray = arCam.ViewportPointToRay(new Vector3(0.5f,0.5f));
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            touchPosition = touch.position;
            if (aRRaycastManager.Raycast(touchPosition, hits))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Hit");
                    if (hit.collider.gameObject.CompareTag("ARPlane"))
                    {
                        Debug.Log("Plane");
                        objectIsSpawned = true;
                        var hitPose = hits[0].pose;
                        roomPrefab.SetActive(true);
                        roomPrefab.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);

                        foreach (ARPlane aRPlane in aRPlaneManager.trackables)
                        {
                            aRPlane.gameObject.SetActive(false);
                        }
                        Destroy(aRPlaneManager);
                        return;
                    }
                  
                }
                
            }


        }        
    }
}
