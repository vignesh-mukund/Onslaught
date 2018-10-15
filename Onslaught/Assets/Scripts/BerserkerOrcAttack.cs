using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerOrcAttack : EnemyProjectile
{

    PlayerStats pStats;

    public GameObject berserkerOrc;


    void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        damage = berserkerOrc.GetComponent<EnemyStats>().damage;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Home Tower")
        {
            pStats.curHealth -= berserkerOrc.GetComponent<EnemyStats>().damage;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}