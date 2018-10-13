using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenTheSkies : ActiveSpell {
    
    PlayerController pController;
    PlayerStats pStats;
    float timer;
    float cdTimer;

    private void Start()
    {
        pController = GameObject.Find("Archer").GetComponent<PlayerController>();
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        spellLevel = 1;
        cooldown = 20;
        duration = 5;
        timer = 0;
    }

    private void Update()
    {
        if (pController.isActive == PlayerController.ActiveAttack.Spell1)
        {
            ActivateSpell();
            print("Arrow Shower");
            timer = Time.time + duration;
        }
        if (Time.time >= timer)
        {
            pStats.curDamage = pStats.baseDamage;
        }
    }

    public void ActivateSpell()
    {
        
    }
}
