using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class explode : MonoBehaviour
{
    public GameObject explosion;
    public GameObject enemyToSpawn;
    Vector3 killPos;
    Quaternion killRot;
    public float waitTime = 3.0f;

    TextMeshProUGUI score_text;
    GameObject scoreBoardUI;

    public TextMeshProUGUI keyMessage;
    bool keyMessageShown = false;
    float keyMessageStartTime;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoardUI = GameObject.FindGameObjectWithTag("scoreboard_tag");
        score_text = GameObject.FindGameObjectWithTag("text_score").GetComponent<TextMeshProUGUI>();
        keyMessage = GameObject.FindGameObjectWithTag("key_tag").GetComponent<TextMeshProUGUI>();
        keyMessage.text = "";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "spider")
        {
            // Save position and rotation before destroying the object
            killPos = collision.transform.position;
            killRot = collision.transform.rotation;

            // Instantiate explosion effect
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);

            // Destroy the spider
            Destroy(collision.gameObject);
            score_board_changer.score += 5;
            score_text.text = "Score: " + score_board_changer.score.ToString();

            if (score_board_changer.score == 30 && !keyMessageShown)
            {
                ShowKeyMessage();
                Debug.Log("score in 30");
            }

            // Schedule enemy respawn through the manager
            RespawnManager.Instance.ScheduleRespawn(enemyToSpawn, killPos, killRot, waitTime);

            // Destroy the current game object
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Collision detected with non-spider object.");
        }
    }

    void Update()
    {
        // Check if key message is shown and scene is loaded
        if (keyMessageShown && SceneManager.GetActiveScene().name == "scene2")
        {
            // Your logic here if needed
        }
    }

    void ShowKeyMessage()
    {
        Debug.Log("ShowKeyMessage called");
        if (keyMessage != null)
        {
            keyMessage.text = "You obtained Key1 for the treasure! now you ll be redirected to fight the final boss but you have to find the poster placed in the cafeteria so you can fight it and obtain the final key!!";
            Debug.Log("Key message displayed");
            keyMessageShown = true;
            keyMessageStartTime = Time.time;
     //       SceneManager.LoadScene("scene_treasure");
        }
    }
}
