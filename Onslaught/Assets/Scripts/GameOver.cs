using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    PlayerStats pStats;

    public float restartDelay;

    Animator anim;
    float restartTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if(pStats.curHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            StartCoroutine(GameOverScreen());
        }
    }

    IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;

    }
}
