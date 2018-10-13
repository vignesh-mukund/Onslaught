using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour {

    BowBehaviour bBehaviour;
    PlayerStats playerStats;

    public bool arrowFired = false;

    float damage;

    private void Start()
    {
        bBehaviour = GameObject.Find("Bow").GetComponent<BowBehaviour>();
        playerStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        damage = playerStats.curDamage;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Home Tower")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<EnemyStats>().curHealth -= damage;
        }
    }
    void Update()
    {
        if (!bBehaviour.aimAssist && bBehaviour.arrowFired)
        {
            this.transform.right = Vector3.Slerp(this.transform.right, this.GetComponent<Rigidbody2D>().velocity.normalized, 100*Time.deltaTime);
        }

    }
}
