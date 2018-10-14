using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherOrcBehaviour : MonoBehaviour {

    EnemyStats archerStats;
    GameController gController;
    LevelSystem lSystem;

	// Use this for initialization
	void Start () {
        gController = GameObject.Find("GameController").GetComponent<GameController>();
        lSystem = GameObject.Find("GameController").GetComponent<LevelSystem>();
        archerStats = this.GetComponent<EnemyStats>();
        archerStats.curHealth = 10;
        archerStats.movementSpeed = 0.6f;
        archerStats.expReward = 20;
        gController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.transform.position.x >= -0.5)
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-archerStats.movementSpeed, 0f);
        }

        if (this.transform.position.x <= -0.5)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }

        if (archerStats.curHealth <= 0)
        {
            lSystem.UpdateExp(archerStats.expReward);
            Destroy(this.gameObject);
            gController.enemiesAlive--;
        }

    }
}
