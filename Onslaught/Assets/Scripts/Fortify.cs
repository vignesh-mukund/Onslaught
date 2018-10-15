using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortify : PassiveSpell {
    
    PlayerStats pStats;

    float passiveAmount;

    private void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        skillDescription = "Permanently increase your watch tower's hitpoints by " + amount + ". Hitpoints already boosted by " + passiveAmount.ToString() + ".";
    }

    public void ApplySpell()
    {
        pStats.maxHealth += amount;
        passiveAmount += amount;
        if(pStats.curHealth < pStats.maxHealth)
        {
            pStats.curHealth += amount;
            if (pStats.curHealth >= pStats.maxHealth)
            {
                pStats.curHealth = pStats.maxHealth;
            }
        }
    }

}
