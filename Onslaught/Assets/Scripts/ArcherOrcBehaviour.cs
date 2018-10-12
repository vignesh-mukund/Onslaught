using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherOrcBehaviour : MonoBehaviour {

    EnemyStats archerStats;

	// Use this for initialization
	void Start () {
        archerStats = this.GetComponent<EnemyStats>();
        archerStats.health = 10;
        archerStats.movementSpeed = 0.6f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.transform.position.x >= -8.5)
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-archerStats.movementSpeed, 0f);
        }

        if (this.transform.position.x <= -8.5)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }

        if (archerStats.health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
