using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : ActiveSpell {

    PlayerController pController;
    PlayerStats pStats;
    float timer;
    float cdTimer;


    private void Start()
    {
        pController = GameObject.Find("Archer").GetComponent<PlayerController>();
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        spellLevel = 1;
        timer = 0f;
        cooldown = 20;
        duration = 4.0f;
    }

    private void Update()
    {
        if (pController.isActive == PlayerController.ActiveAttack.Spell2)
        {
            //Invoke("ActivateSpell", 1.0f);
            timer = Time.time + duration;
            print(timer);
        }
        if (Time.time >= timer)
        {
            pStats.curDamage = pStats.baseDamage;
        }
    }

    public void ActivateSpell()
    {
        pStats.curDamage = 2 * pStats.baseDamage;
    }
}
