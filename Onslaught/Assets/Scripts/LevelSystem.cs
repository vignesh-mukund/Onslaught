using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {

    PlayerStats pStats;
    EnemyStats eStats;
    

	void Start ()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
	}
	
	void Update ()
    {
	}

    public void UpdateExp(int exp)
    {
        pStats.curExp += exp;
        int curLevel = 1 + (int)(0.1f * Mathf.Sqrt(pStats.curExp));

        if(curLevel != pStats.level)
        {
            pStats.level = curLevel;
            pStats.unspentSkillPoints += 1;
        }

        /*int expNextLevel = 100 * (pStats.level + 1);
        int difference = expNextLevel - pStats.curExp;

        int totalDifference = expNextLevel - (100 * pStats.level * pStats.level);
        */

    }
}
