using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{

    PlayerStats pStats;

    float timer;

    void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        StartCoroutine(RegenHealth());
    }

    private void Update()
    {

    }

    IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(pStats.healthRegenTimer);
        while (pStats.curHealth < pStats.maxHealth)
        {
            pStats.curHealth += pStats.healthRegen;
            yield return new WaitForSeconds(1.0f);
        }
        this.gameObject.GetComponent<PlayerRegen>().regenHealthOn = false;
        Destroy(this);
    }

}
