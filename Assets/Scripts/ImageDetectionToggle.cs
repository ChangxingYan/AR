using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageDetectionToggle : MonoBehaviour
{
    private ARTrackedImageManager imageManager;

    [SerializeField]
    private GameObject UIPanel;
    private void Awake()
    {
        imageManager = GetComponent<ARTrackedImageManager>();

    }

    public void ToggleImageDetection()
    {
        imageManager.enabled = !imageManager.enabled;
        if (imageManager.enabled)
        {
            SetAllImagesActive(true);
        }
        else
        {
            UIPanel.SetActive(false);
            SetAllImagesActive(false);
        }
    }

    private void SetAllImagesActive(bool value)
    {
        foreach(var image in imageManager.trackables)
        {
            image.gameObject.SetActive(value);
        }
    }

}
