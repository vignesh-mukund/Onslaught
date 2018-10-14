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
        timer = 0f;
    }

    private void Update()
    {
        if (pController.isActive == PlayerController.ActiveAttack.Spell2)
        {
            ActivateSpell();
            pController.spell2CDTimer = Time.time + cooldown;
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
