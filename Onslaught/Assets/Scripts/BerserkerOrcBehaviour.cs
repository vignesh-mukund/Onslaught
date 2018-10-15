using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerOrcBehaviour : MonoBehaviour {

    PlayerStats pStats;

    EnemyStats berserkerStats;
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

        berserkerStats = this.GetComponent<EnemyStats>();

        berserkerStats.maxHealth = berserkerStats.maxHealth * Mathf.Sqrt(pStats.level);
        berserkerStats.damage = berserkerStats.damage * Mathf.Sqrt(pStats.level);
        berserkerStats.expReward = (int)(berserkerStats.expReward * Mathf.Sqrt(pStats.level));

        berserkerStats.curHealth = berserkerStats.GetComponent<EnemyStats>().maxHealth;

        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (berserkerStats.curHealth <= 0)
        {
            lSystem.UpdateExp(berserkerStats.expReward);
            attacking = false;
            Destroy(this.gameObject);
            gController.enemiesAlive--;
        }
        else if (berserkerStats.curHealth > 0)
        {
            if (this.transform.position.x > -9.4)
            {

                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-berserkerStats.movementSpeed, 0f);
                attacking = false;
            }
            else if (this.transform.position.x <= -9.4)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                if (!attacking)
                {
                    StartCoroutine(BerkerserkerOrcAttack());
                    attacking = true;
                }
            }
        }
    }

    IEnumerator BerkerserkerOrcAttack()
    {
        yield return new WaitForSeconds(1.0f);
        while (this.transform.position.x <= -9.4)
        {
            float x = this.transform.position.x - 0.1f;
            float y = this.transform.position.y + 0.1f;
            Rigidbody2D arrow = Instantiate(projectile, new Vector3(x, y, 0), Quaternion.identity) as Rigidbody2D;
            arrow.velocity = 2f * (new Vector3(Random.Range(-1f, -0.5f), Random.Range(0.2f, 0.5f), 0.0f));
            arrow.bodyType = RigidbodyType2D.Dynamic;
            arrow.mass = 0.0F;
            arrow.angularDrag = 0.0F;
            arrow.drag = 0.0F;

            yield return new WaitForSeconds(1.0f / berserkerStats.attackSpeed);
        }
    }
}
