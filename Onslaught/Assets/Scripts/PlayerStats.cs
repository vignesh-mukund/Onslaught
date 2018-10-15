using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats : MonoBehaviour {

    [Header ("Player Stats")]
    public string userName;
    public int level;
    
    public float baseDamage;
    public float curDamage;

    public float maxHealth;
    public float curHealth;

    public float maxMagic;
    public float curMagic;

    public float magicRegen;
    public float healthRegen;
    public float healthRegenTimer;

    public int maxExp;
    public int curExp;

    public int unspentSkillPoints;
    public int spentSkillPoints;

    public float movementSpeed;
    public float attackSpeed;

    public bool isDead;

    float health;
    float magic;
    float exp;

    [Header ("Player Skills")]
    public List<Skills> Skills = new List<Skills>();

    private void Start()
    {
        baseDamage = 10f;
        maxHealth = 200f;
        maxMagic = 10f;
    }

    private void Update()
    {
        if(curHealth <= 0)
        {
            curHealth = 0;
        }
    }
}
