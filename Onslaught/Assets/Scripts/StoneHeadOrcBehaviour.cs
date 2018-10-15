using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHeadOrcBehaviour : MonoBehaviour
{ 
    PlayerStats pStats;

    EnemyStats stoneHeadStats;
    GameController gController;
    LevelSystem lSystem;

    public Rigidbody2D projectile;

    bool attacking;

    // Use this for initialization
    void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        gController = GameObject.Find("GameController").GetComponent<GameController>();
        lSystem = GameObject.Find("GameController").GetComponent<LevelSystem>();

        stoneHeadStats = this.GetComponent<EnemyStats>();

        stoneHeadStats.maxHealth = stoneHeadStats.maxHealth * Mathf.Sqrt(pStats.level);
        stoneHeadStats.damage = stoneHeadStats.damage * Mathf.Sqrt(pStats.level);
        stoneHeadStats.expReward = (int)(stoneHeadStats.expReward * Mathf.Sqrt(pStats.level));

        stoneHeadStats.curHealth = stoneHeadStats.GetComponent<EnemyStats>().maxHealth;
        
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stoneHeadStats.curHealth <= 0)
        {
            lSystem.UpdateExp(stoneHeadStats.expReward);
            attacking = false;
            Destroy(this.gameObject);
            gController.enemiesAlive--;
        }
        else if (stoneHeadStats.curHealth > 0)
        {
            if (this.transform.position.x > -8.6)
            {

                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-stoneHeadStats.movementSpeed, 0f);
                attacking = false;
            }
            else if (this.transform.position.x <= -8.6)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                if (!attacking)
                {
                    StartCoroutine(StoneHeadOrcAttack());
                    attacking = true;
                }
            }
        }
    }

    IEnumerator StoneHeadOrcAttack()
    {
        yield return new WaitForSeconds(1.0f);
        while (this.transform.position.x <= -8.6)
        {
            float x = this.transform.position.x - 0.1f;
            float y = this.transform.position.y + 0.1f;
            Rigidbody2D arrow = Instantiate(projectile, new Vector3(x, y, 0), Quaternion.identity) as Rigidbody2D;
            arrow.velocity = 6f * (new Vector3(Random.Range(-1f, -0.5f), Random.Range(0.2f, 0.5f), 0.0f));
            arrow.bodyType = RigidbodyType2D.Dynamic;
            arrow.mass = 0.0F;
            arrow.angularDrag = 0.0F;
            arrow.drag = 0.0F;

            yield return new WaitForSeconds(1.0f / stoneHeadStats.attackSpeed);
        }
    }
}

