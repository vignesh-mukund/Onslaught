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
            ActivateSpell();
            timer = Time.time + duration;
            pController.isActive = PlayerController.ActiveAttack.None;
        }
        if (Time.time >= timer)
        {
            pStats.curDamage = pStats.baseDamage;
        }
    }

    void ActivateSpell()
    {
        pStats.curDamage = 2f * pStats.baseDamage;
    }
}
