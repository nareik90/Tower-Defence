using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    public int scoreValue;
    private GameController gameController;

    void Start ()
	{
        // Navigate to Castle
        GameObject castle = GameObject.Find("Castle");
        if (castle)
            GetComponent<NavMeshAgent>().destination = castle.transform.position;

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


    void OnTriggerEnter(Collider co)
    {
        // If castle then deal Damage, destroy self
        if (co.name == "Castle")
        {
            co.GetComponentInChildren<Health>().decrease();
            Destroy(gameObject);
        }

        if (co.name == "Bullet")
        {
            gameController.AddScore(scoreValue);
            Debug.Log("Scored..........");
        }
       

    }
}
