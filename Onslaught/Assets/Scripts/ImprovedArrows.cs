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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("ApplySpell", 0.0f);
        }
    }

    public void ApplySpell()
    {
        pStats.baseDamage += (spellLevel * amount);

    }
}
