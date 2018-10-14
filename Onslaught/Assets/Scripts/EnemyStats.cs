using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats : MonoBehaviour {

    [Header ("Enemy Stats")]
    public float maxHealth;
    public float curHealth;
    public float movementSpeed;
    public int expReward;

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
