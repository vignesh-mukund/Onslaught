using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float damage;
    public float maxHealth;
    public float maxMagic;
    public float maxExp;
    public float magicRegen;

    float health;
    float magic;
    float exp;

    private void Start()
    {
        damage = 10f;
        maxHealth = 200f;
        maxMagic = 10f;
        maxExp = 100f;
    }
}
