using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRegen : MonoBehaviour {

    PlayerStats pStats;

    float timer;
    
	void Start ()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        StartCoroutine(RegenMagic());

	}

    private void Update ()
    {
        
    }

    IEnumerator RegenMagic()
    {
        yield return new WaitForSeconds(1.0f);
        while (pStats.curMagic < pStats.maxMagic)
        {
            pStats.curMagic += pStats.magicRegen;
            yield return new WaitForSeconds(1.0f);
        }
        this.gameObject.GetComponent<PlayerRegen>().regenMagicOn = false;
        Destroy(this);
    }
    
}
