using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class Ar_cursor_script : MonoBehaviour
{
    public GameObject cursor_child_object;
    public GameObject object_to_place; // This should be the spider_parent prefab
    public ARRaycastManager arRaycastManager;
    public Button instantiateButton; // UI Button to trigger instantiation

    public bool is_cursor_active = true;

    // Start is called before the first frame update
    void Start()
    {
        cursor_child_object.SetActive(is_cursor_active);

        if (arRaycastManager == null)
        {
            Debug.LogError("AR Raycast Manager is not set");
        }

        if (object_to_place == null)
        {
            Debug.LogError("Object to place is not set");
        }

        if (instantiateButton == null)
        {
            Debug.LogError("Instantiate button is not set");
        }
        else
        {
            // Remove all listeners first to prevent multiple calls
            instantiateButton.onClick.RemoveAllListeners();
            instantiateButton.onClick.AddListener(OnInstantiateButtonClick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_cursor_active)
        {
            UpdateCursor();
        }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            Debug.Log("Cursor updated to position: " + transform.position + ", rotation: " + transform.rotation);
        }
    }

    void InstantiateObject(Vector3 position, Quaternion rotation)
    {
        // Ensure the position is close to the camera
        Vector3 adjustedPosition = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;
        GameObject spawnedObject = Instantiate(object_to_place, adjustedPosition, rotation);
        spawnedObject.transform.localScale = Vector3.one * 0.1f; // Adjust the scale if needed
        Debug.Log("Instantiated object at position: " + adjustedPosition + ", rotation: " + rotation + ", scale: " + spawnedObject.transform.localScale);
    }

    public void OnInstantiateButtonClick()
    {
        Debug.Log("Instantiate button clicked");

        if (is_cursor_active)
        {
            InstantiateObject(transform.position, transform.rotation);
        }
        else
        {
            Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            arRaycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (hits.Count > 0)
            {
                InstantiateObject(hits[0].pose.position, hits[0].pose.rotation);
            }
        }
    }
}
