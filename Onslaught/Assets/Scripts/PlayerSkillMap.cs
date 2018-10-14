using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillMap : MonoBehaviour {

    PlayerStats pStats;
    LevelSystem lSystem;

    public DarkenTheSkies darkenTheSkiesSpell;
    public HeadShot headShotSpell;
    public Fortify fortifySpell;
    public ImprovedArrows improvedArrowsSpell;


    
	void Start ()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        lSystem = GameObject.Find("GameController").GetComponent<LevelSystem>();
	}
	
	void Update ()
    {
        if (pStats.unspentSkillPoints >= 1)
        {
            StartCoroutine(UnspentSkillPoints());
        }
        else return;

        //check button press and level up corresponing skill.
	}

    IEnumerator UnspentSkillPoints()
    {
        while (pStats.unspentSkillPoints >= 1)
        {
            //enable skill level up button
            yield return null;
        }
    }

    public void UpdateSkillMap(Spell spell)
    {
        spell.spellLevel++;
        pStats.spentSkillPoints++;
        pStats.unspentSkillPoints--;

        if (spell == fortifySpell)
        {
            fortifySpell.ApplySpell();
        }

        if(spell == improvedArrowsSpell)
        {
            improvedArrowsSpell.ApplySpell();
        }
        
    }
}
