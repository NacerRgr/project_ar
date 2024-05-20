using System.Reflection;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class prefabCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject drangonPrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject dragon;
    private ARTrackedImageManager arTrackedImageManager;


    private void OnEnable()
    {
        arTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        arTrackedImageManager.trackedImagesChanged += OnImagechanged;
    }

    // Update is called once per frame
    
    private void OnImagechanged(ARTrackedImagesChangedEventArgs args){
        foreach(ARTrackedImage trackedImage in args.added){
            
            dragon = Instantiate(drangonPrefab, trackedImage.transform);
            dragon.transform.position += prefabOffset;
        }
    }
}
