using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	
    public GameController gameController;
    public GUIText RestartText;
    public GUIText GameOverText;
    public bool spawn = true;
    private bool gameOver = false;
    private bool restart = false;
    
    // The Monster that should be spawned
    public GameObject monsterPrefab;
    
    // Spawn Delay in seconds
    public float interval = 10;
    
    
    
    // Use this for initialization
    void Start()
    {  
       
        RestartText.text = "";
        GameOverText.text = "";

        
        InvokeRepeating("SpawnNext", interval, interval);
        
    }
    
     void Update ()
    {

        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel (Application.loadedLevel);
                Debug.Log("Restart with R");
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Application.LoadLevel("TestAzure");
            
        }

    }
    
    void SpawnNext() {

        if (spawn == true)
        {
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }

        if (gameOver == true)
        {

            RestartText.text = "Press 'R' for Restart";
            restart = true;
            spawn = false;
            Debug.Log("gameover invoked");
        }


    }
    
    public void GameOver ()
    {
        Debug.Log("Game over method......");
        GameOverText.text = "Game Over! Press R to restart or S to submit score";
        
        gameOver = true;
        spawn = false;
        restart = true;
    }
}