using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	
    public GameController gameController;
    public GUIText RestartText;
    public GUIText GameOverText;
    public bool spawn = true;
    private bool gameOver;
    private bool restart;

    // The Monster that should be spawned
    public GameObject monsterPrefab;
    
    // Spawn Delay in seconds
    public float interval = 10;
    
    
    
    // Use this for initialization
    void Start()
    {  
        gameOver = false;
        restart = false;
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
            }
        }
    }
    
    void SpawnNext() {
        
        Instantiate(monsterPrefab, transform.position, Quaternion.identity);
  
            if (gameOver)
            {
                RestartText.text = "Press 'R' for Restart";
                restart = true;
               
            }
          
    }
    
    public void GameOver ()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }
}
