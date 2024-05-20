using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlaceIndicator placeIndicator;
    public GameObject Object_to_place;

    private GameObject newPlacedObject;
    
    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();    
    }

    

    public void ClickToPlace(){
        newPlacedObject = Instantiate(Object_to_place, placeIndicator.transform.position, placeIndicator.transform.rotation);
    }
}
