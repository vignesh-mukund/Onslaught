using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public Rigidbody2D Enemy1;
    public Rigidbody2D Enemy2;
    //public Transform enemySpawn;

    int enemies;

	// Use this for initialization
	void Start ()
    {
        enemies = 0;
        InvokeRepeating("SpawnEnemy1", 1.0f, 3.0f);
        InvokeRepeating("SpawnEnemy2", 3.0f, 5.0f);

    }
	
	// Update is called once per frame
	void Update () {
        if (enemies >= 10)
        {
            CancelInvoke();
        }
	}

    void SpawnEnemy1()
    {
        float x = Random.Range(16.0f, 22.0f);
        Rigidbody2D spawnedEnemy1 = Instantiate(Enemy1, new Vector3(x, -3.2f, 0f),Quaternion.identity);
        ++enemies;
    }

    void SpawnEnemy2()
    {
        float x = Random.Range(16.0f, 22.0f);
        Rigidbody2D spawnedEnemy1 = Instantiate(Enemy2, new Vector3(x, -3.2f, 0f), Quaternion.identity);
        ++enemies;
    }

}
