using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bullet2 : MonoBehaviour
{
    public GameObject explosion;
    public GameObject enemyToSpawn;
    Vector3 killPos;
    Quaternion killRot;

    public TextMeshProUGUI keyMessage; 



    // Start is called before the first frame update
    void Start()
    {

        keyMessage = GameObject.FindGameObjectWithTag("congrats").GetComponent<TextMeshProUGUI>();
        keyMessage.text = "";

     }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "albino")
        {

            // Save position and rotation before destroying the object
            killPos = collision.transform.position;
            killRot = collision.transform.rotation;
        
            // Instantiate explosion effect
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);

            // Destroy the spider
            Destroy(collision.gameObject);
            
    
            keyMessage.text = "Congrats on killing the boss now to find the tresor u should go find the marker at the place where we rest in ensim btw 12h-14h!!";
            

            // Destroy the current game object
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Collision detected with non-spider object.");
        }
    }


   
}
