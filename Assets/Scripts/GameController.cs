using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    
   
    public GUIText scoreText;
    private int score;
    int highScore = 0;
    public Spawn spawn;


    void Start ()
    {
        highScore = PlayerPrefs.GetInt("High Score");
        score = 0;
        UpdateScore ();
    }

   

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        Debug.Log("Scored..........");
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;

        if (score > highScore ) {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);

            Debug.Log("High Score is " + highScore);
        }


    }
    
}
