using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerOrcBehaviour : MonoBehaviour {
    

    EnemyStats berserkerStats;

    // Use this for initialization
    void Start()
    {
        berserkerStats = this.GetComponent<EnemyStats>();
        berserkerStats.health = 30;
        berserkerStats.movementSpeed = 0.55f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x >= -9.4)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-berserkerStats.movementSpeed, 0f);
        }

        if (this.transform.position.x <= -9.4)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }

        if (berserkerStats.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
