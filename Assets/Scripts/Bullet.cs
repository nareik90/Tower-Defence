using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	  // Speed
    public float speed = 10;

    // Target (set by Tower)
    public Transform target;

    public int scoreValue;
    private GameController gameController;

    // Use this for initialization
    void Start ()
	{
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void FixedUpdate() {
    // Still has a Target?
    if (target) {
        // Fly towards the target        
        Vector3 dir = target.position - transform.position;
        GetComponent<Rigidbody>().velocity = dir.normalized * speed;
    } else {
        // Otherwise destroy self
        Destroy(gameObject);
			
    }
    }
	
	void OnTriggerEnter(Collider co) 
    {
        gameController.AddScore(scoreValue);
        Debug.Log("Scored..........");

        Health health = co.GetComponentInChildren<Health>();
        if (health) 
        {
            health.decrease();
            Destroy(gameObject);
        }

    }
	
}
