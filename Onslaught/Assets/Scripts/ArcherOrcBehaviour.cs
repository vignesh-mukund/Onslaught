using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherOrcBehaviour : MonoBehaviour {

    PlayerStats pStats;
    EnemyStats archerOrcStats;
    GameController gController;
    LevelSystem lSystem;

    public Rigidbody2D projectile;

    bool attacking;



	// Use this for initialization
	void Start () {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        gController = GameObject.Find("GameController").GetComponent<GameController>();
        lSystem = GameObject.Find("GameController").GetComponent<LevelSystem>();

        archerOrcStats = this.GetComponent<EnemyStats>();
        archerOrcStats.maxHealth = archerOrcStats.maxHealth * Mathf.Sqrt(pStats.level);
        archerOrcStats.damage = archerOrcStats.damage * Mathf.Sqrt(pStats.level);
        archerOrcStats.expReward = (int)(archerOrcStats.expReward * Mathf.Sqrt(pStats.level));

        archerOrcStats.curHealth = archerOrcStats.maxHealth;
        
        attacking = false;
	}
	
	void Update ()
    {

        if (archerOrcStats.curHealth <= 0)
        {
            lSystem.UpdateExp(archerOrcStats.expReward);
            attacking = false;
            Destroy(this.gameObject);
            gController.enemiesAlive--;
        }
        else if (archerOrcStats.curHealth > 0)
        {
            if (this.transform.position.x > -0.5)
            {

                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-archerOrcStats.movementSpeed, 0f);
                attacking = false;
            }
            else if (this.transform.position.x <= -0.5)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                if (!attacking)
                {
                    StartCoroutine(ArcherOrcAttack());
                    attacking = true;
                }
            }
        }

    }

    IEnumerator ArcherOrcAttack()
    {
        yield return new WaitForSeconds(1.0f);
        while (this.transform.position.x <= -0.5)
        {
            float x = this.transform.position.x - 0.5f;
            float y = this.transform.position.y + 0.2f;
            Rigidbody2D arrow = Instantiate(projectile, new Vector3(x, y, 0), Quaternion.identity) as Rigidbody2D;
            arrow.velocity = 3f * (new Vector3(Random.Range(-4f, -3f), Random.Range(2f, 2.7f), 0.0f));
            arrow.bodyType = RigidbodyType2D.Dynamic;
            arrow.mass = 0.5F;
            arrow.angularDrag = 0.0F;
            arrow.drag = 0.0F;

            yield return new WaitForSeconds(1.0f/archerOrcStats.attackSpeed);
        }
    }
}
