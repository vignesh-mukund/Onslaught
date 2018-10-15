using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRegen : MonoBehaviour {

    PlayerStats pStats;

    public bool regenHealthOn;
    public bool regenMagicOn;

    public bool incomingDamage;

    public float timer;
    
	void Start ()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        regenHealthOn = false;
        regenMagicOn = false;
        incomingDamage = false;
        timer = 0f;
	}

    void Update()
    {
        if (Time.time > timer)
        {
            incomingDamage = false;
            if (pStats.curHealth < pStats.maxHealth && !regenHealthOn)
            {
                this.gameObject.AddComponent<HealthRegen>();
                regenHealthOn = true;
            }
        }

        if (pStats.curMagic < pStats.maxMagic && !regenMagicOn)
        {
            this.gameObject.AddComponent<MagicRegen>();
            regenMagicOn = true;
        }

        if (incomingDamage)
        {
            Destroy(this.gameObject.GetComponent<HealthRegen>());
        }
	}
}
