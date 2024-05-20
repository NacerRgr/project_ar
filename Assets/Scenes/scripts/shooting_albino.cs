using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_albino : MonoBehaviour
{
    public Camera mainCamera; // Reference to the Main Camera component
    public GameObject explosion; // Explosion prefab to instantiate

    private RaycastHit hit;

    public GameObject projectile;



    // Update is called once per frame
    void Update()
    {
        // Handle touch input for shooting
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Shoot2(Input.GetTouch(0).position);
        }

        // Add mouse input for debugging in the editor
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse click detected");
            Shoot2(Input.mousePosition);
        }
    }

   public void Shoot2(Vector2 screenPosition)
    {
        // Use ray from the Main Camera for touch and mouse input
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        Debug.Log("Ray origin: " + ray.origin + ", direction: " + ray.direction); // Log ray origin and direction

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit object: " + hit.transform.name + " with tag: " + hit.transform.tag); // Log the hit object and its tag

            if (hit.transform.CompareTag("albino"))
            {
                // Debug.Log("Destroying object: " + hit.transform.name); // Log the object being destroyed
                // Destroy(hit.transform.gameObject);
                // Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                // Destroy(explosion, 2f);  // Destroy the explosion after 2 seconds

                GameObject bullet = Instantiate(projectile,mainCamera.transform.position,mainCamera.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * 500f);
            
            }
            else
            {
                Debug.Log("Object hit does not have the 'spider' tag");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any object");
        }
    }

      public void OnShootButtonPress()
    {
        // Call the Shoot method with a predefined screen position or use the center of the screen
        Vector2 screenPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        Shoot2(screenPosition);
    }



}
