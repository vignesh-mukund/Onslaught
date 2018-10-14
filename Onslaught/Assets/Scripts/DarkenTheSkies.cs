﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenTheSkies : ActiveSpell {
    
    PlayerController pController;
    PlayerStats pStats;                 // Fetching global player stats.
    DarkenTheSkies dts;

    public LineRenderer lr;             // This draws the aoe marker around the mouse position.
    public ParticleSystem ps;           // Particle system to show AOE FX.

    Vector3 mouse_pos;                  // Mouse position.
    Vector3 player_pos;                 // Back-up variable for camera to viewport calculations.
    Vector3 pos;                        // Holds raycast translated mouse pos values.

    public float range;                        //
    float timer;
    float cdTimer;
    public float damageTickDuration;

    private void Start()
    {
        pController = GameObject.Find("Archer").GetComponent<PlayerController>();
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        timer = 0;
        lr.enabled = false;
        ps.Pause();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, transform.position);
        float dist = 0;
        if(plane.Raycast(ray, out dist)){
            pos = ray.GetPoint(dist);
        }

        if (pController.isActive == PlayerController.ActiveAttack.Spell1)
        {
            AOEMarker();
        }
    }

    void AOEMarker()
    {
        lr.enabled = true;
        this.transform.position = new Vector3(pos.x, -3.2f, 0);
        lr.positionCount = 2;
        lr.SetPosition(0, new Vector3((pos.x - (range / 2)), -3.4f, 0));
        lr.SetPosition(1, new Vector3((pos.x + (range / 2)), -3.4f, 0));

        if (Input.GetMouseButtonDown(0))
        {
            timer = Time.time + duration;
            StartCoroutine(ActivateSpell());
            pController.isActive = PlayerController.ActiveAttack.None;
        }
    }

    IEnumerator ActivateSpell()
    {
        var emission = ps.emission;
        lr.enabled = false;
        Rigidbody2D aoeBox = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        aoeBox.isKinematic = true;
        aoeBox.gravityScale = 0.0f;
        BoxCollider2D aoeCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        aoeCollider.size = new Vector2(2.5f, 2f);
        aoeCollider.isTrigger = true;
        while (Time.time <= timer)
        {
            emission.enabled = true;
            ps.Play();            
            yield return 0;
        }
        Destroy(aoeCollider);
        Destroy(aoeBox);
        emission.enabled = false ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with:" + other.gameObject.name);
            var dps = other.gameObject.AddComponent<DamageOverTime>();
            dps.Duration = duration;
            dps.Damage = (spellLevel * damage);
            dps.DamageTickDuration = 1;
        }
        return;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var dps = other.gameObject.GetComponent<DamageOverTime>();
            Destroy(dps);
        }
        return;
    }
}
