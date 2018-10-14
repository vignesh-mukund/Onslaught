using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedArrows : PassiveSpell
{

    PlayerController pController;
    PlayerStats pStats;

    private void Start()
    {
        pController = GameObject.Find("Archer").GetComponent<PlayerController>();
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        spellLevel = 1;
        amount = 10;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("ApplySpell", 0.0f);
        }
    }

    void ApplySpell()
    {
        pStats.baseDamage = pStats.baseDamage + (spellLevel * amount);

    }
}
