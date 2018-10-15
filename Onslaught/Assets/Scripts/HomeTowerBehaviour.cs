using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTowerBehaviour : MonoBehaviour {

    PlayerStats pStats;
    PlayerRegen pRegen;
    
    void Start ()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        pRegen = GameObject.Find("Archer").GetComponent<PlayerRegen>();

    }
	
	void Update ()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy Projectile"))
        {
            pRegen.incomingDamage = true;
            pRegen.timer = Time.time + pStats.healthRegenTimer;
        }
    }
}
