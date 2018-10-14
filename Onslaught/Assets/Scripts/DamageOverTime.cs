using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour {
    public float Damage { get; set; }
    public float Duration { get; set; }
    public float DamageTickDuration { get; set; }

    private int appliedTimes = 0;

    // Use this for initialization
    void Start () {

        StartCoroutine(DPS( ));

    }

    IEnumerator DPS()
    {

        while (appliedTimes < (int)(Duration/DamageTickDuration))
        {
            this.GetComponent<EnemyStats>().curHealth -= Damage;
            yield return new WaitForSeconds(DamageTickDuration);
            appliedTimes++;
        }

        Destroy(this);
    }
  
}
