using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerOrcBehaviour : MonoBehaviour {
    

    EnemyStats berserkerStats;
    GameController gController;
    LevelSystem lSystem;

    // Use this for initialization
    void Start()
    {
        gController = GameObject.Find("GameController").GetComponent<GameController>();
        lSystem = GameObject.Find("GameController").GetComponent<LevelSystem>();
        berserkerStats = this.GetComponent<EnemyStats>();
        berserkerStats.curHealth = 30;
        berserkerStats.movementSpeed = 0.55f;
        berserkerStats.expReward = 40;
        gController = GameObject.Find("GameController").GetComponent<GameController>();
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

        if (berserkerStats.curHealth <= 0)
        {
            lSystem.UpdateExp(berserkerStats.expReward);
            Destroy(this.gameObject);
            gController.enemiesAlive--;
        }
    }
}
