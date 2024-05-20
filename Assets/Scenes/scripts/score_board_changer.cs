using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_board_changer : MonoBehaviour
{
    // Start is called before the first frame update
    
    TextMeshProUGUI score_text;
    GameObject scoreBoardUI;

    public static int score;

    private void Start()
    {
        Debug.Log("Start method called");

        gameObject.GetComponent<explode>().enabled = true;
        Debug.Log("Explode component enabled");

        scoreBoardUI = GameObject.FindGameObjectWithTag("scoreboard_tag");
        if (scoreBoardUI != null)
        {
            Debug.Log("Scoreboard UI found");
        }
        else
        {
            Debug.LogError("Scoreboard UI not found");
        }

        score_text = GameObject.FindGameObjectWithTag("text_score").GetComponent<TextMeshProUGUI>();
        if (score_text != null)
        {
            Debug.Log("Score text component found");
        }
        else
        {
            Debug.LogError("Score text component not found");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("Update method called");

        if (score_text != null)
        {
            score_text.text = "Score: " + score.ToString();
            Debug.Log("Score updated: " + score.ToString());
        }
        else
        {
            Debug.LogError("Score text component is null in Update method");
        }
    }
}
