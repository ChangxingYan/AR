using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
public class UICon : MonoBehaviour
{
    public GameObject UIPanel;
    string objName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    objName = hit.transform.name;

                    foreach (GameObject go in ImageTracking.spawnedPrefabs.Values)
                    {
                        if (go.name == objName)
                        {

                            UIPanel.SetActive(true);
                            UIPanel.transform.Find(objName).gameObject.SetActive(true);
                        }
                    }
                }
            
        }
    }

    public void ChangeObjects(ARTrackedImageManager trackedManager)
    {
        UIPanel.transform.Find(objName).gameObject.SetActive(false);
        Debug.Log(objName);
        Vector3 position = trackedManager.trackedImagePrefab.transform.position;
        List<string> nameList = new List<string>(ImageTracking.spawnedPrefabs.Keys);
        System.Random rand = new System.Random();
        string randomKey = nameList[rand.Next(nameList.Count)];
        GameObject prefab = ImageTracking.spawnedPrefabs[randomKey];

        prefab.transform.position = position;
        prefab.SetActive(true);
    }

    public void Rescan()
    {
        UIPanel.SetActive(false);
        UIPanel.transform.Find(objName).gameObject.SetActive(false);
    }
    public void CallMenu()
    {
        UIPanel.SetActive(true);
    }
}
