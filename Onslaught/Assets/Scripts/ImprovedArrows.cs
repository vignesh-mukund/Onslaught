using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedArrows : PassiveSpell
{


    PlayerStats pStats;

    float passiveBoosted = 0;

    private void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        skillDescription = "Permanently boost your arrow damage by " + amount + ". " + "Currently boosted by " + passiveBoosted.ToString();
    }

    public void ApplySpell()
    {
        pStats.baseDamage += amount;
        passiveBoosted += amount;

    }
}
