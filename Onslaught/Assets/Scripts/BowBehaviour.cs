using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBehaviour : MonoBehaviour {

    PlayerStats pStats;
    PlayerController pController;
    
    public float bowVelocity = 11.3F;

    public Transform spawn;             // arrow spawn position
    public Rigidbody2D arrowObj;        // arrow projectile object.

    // These bools are flags for various states of the weapon.
    public bool arrowLoaded = false;    // keeps track of next shot.
    public bool arrowFired = false;     // starts arrow-head rotation during transit.
    public bool aimAssist = false;      // enables/disables aiming. not in use atm.

    public bool canShoot = true;        // flag based on pStats aspd.

    public float shootTimer;            // timer tracks elapsed time between shots.

    Vector3 player_pos;

    private void Start()
    {
        bowVelocity = 11.3F;
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        pController = GameObject.Find("Archer").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(pController.isActive == PlayerController.ActiveAttack.None)
        {
            BowShoot();
        }
    }

    void FixedUpdate()
    {
    }

    void BowLoad()
    {

    }

    /* Fetches mouse position to figure out angle at which the arrow should be shot.
     * Also sets AimAssist ON/OFF depending on arrowFired state.
    */
    void BowShoot()
    {
        Vector2 mouse_pos = Input.mousePosition;
        player_pos = Camera.main.WorldToScreenPoint(this.transform.position);
        player_pos.z = 0.0f;

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

        if (canShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                aimAssist = true;
                arrowFired = false;
                arrowLoaded = true;
            }

            if (Input.GetMouseButtonUp(0) && arrowLoaded)
            {
                aimAssist = false;
                arrowFired = true;
                arrowLoaded = false;
                Rigidbody2D arrow = Instantiate(arrowObj, spawn.transform.position, Quaternion.Euler(new Vector3(0, 0, angle))) as Rigidbody2D;
                Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

                arrow.velocity = dir * bowVelocity;
                arrow.bodyType = RigidbodyType2D.Dynamic;
                arrow.mass = 1.0F;
                arrow.angularDrag = 0.0F;
                arrow.drag = 0.0F;
                canShoot = false;
                shootTimer = 0.0F;
            }
        }
        shootTimer += Time.deltaTime;
        if (shootTimer >= 1.0f/pStats.attackSpeed)
        {
            canShoot = true;
        }
        else canShoot = false;
    }
}
