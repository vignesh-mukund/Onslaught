using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteOrcBehaviour : MonoBehaviour
{
    PlayerStats pStats;
    EnemyStats bruteStats;
    GameController gController;
    LevelSystem lSystem;

    public Rigidbody2D projectile;

    bool attacking;


    void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        gController = GameObject.Find("GameController").GetComponent<GameController>();
        lSystem = GameObject.Find("GameController").GetComponent<LevelSystem>();

        bruteStats = this.GetComponent<EnemyStats>();

        bruteStats.maxHealth = bruteStats.maxHealth * Mathf.Sqrt(pStats.level);
        bruteStats.damage = bruteStats.damage * Mathf.Sqrt(pStats.level);
        bruteStats.expReward = (int)(bruteStats.expReward * Mathf.Sqrt(pStats.level));

        bruteStats.curHealth = bruteStats.GetComponent<EnemyStats>().maxHealth;

        attacking = false;
    }

    void Update()
    {

        if (bruteStats.curHealth <= 0)
        {
            lSystem.UpdateExp(bruteStats.expReward);
            attacking = false;
            Destroy(this.gameObject);
            gController.enemiesAlive--;
        }
        else if (bruteStats.curHealth > 0)
        {
            if (this.transform.position.x > -9.2)
            {

                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-bruteStats.movementSpeed, 0f);
                attacking = false;
            }
            else if (this.transform.position.x <= -9.2)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                if (!attacking)
                {
                    StartCoroutine(BruteOrcAttack());
                    attacking = true;
                }
            }
        }
    }

    IEnumerator BruteOrcAttack()
    {
        yield return new WaitForSeconds(1.0f);
        while (this.transform.position.x <= -9.2)
        {
            float x = this.transform.position.x - 0.1f;
            float y = this.transform.position.y + 0.4f;
            Rigidbody2D arrow = Instantiate(projectile, new Vector3(x, y, 0), Quaternion.identity) as Rigidbody2D;
            arrow.velocity = 4f * (new Vector3(Random.Range(-1f, -0.5f), Random.Range(0.5f, 1f), 0.0f));
            arrow.bodyType = RigidbodyType2D.Dynamic;
            arrow.mass = 0.6F;
            arrow.angularDrag = 0.0F;
            arrow.drag = 0.0F;

            yield return new WaitForSeconds(1.0f / bruteStats.attackSpeed);
        }
    }
}

