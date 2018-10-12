using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float maxHealth;
    public float health;
    public float movementSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            Destroy(.gameObject);
            health -= damage;
            Debug.Log(enemyHealth);
        }
    }*/
}
