using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats : MonoBehaviour
{

    [Header("Enemy Stats")]
    public float maxHealth;
    public float curHealth;
    public float damage;
    public float movementSpeed;
    public float attackSpeed;
    public int expReward;

    void Start()
    {
    }

    void Update()
    {
    }
}
