using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBehaviour : MonoBehaviour {


    public KeyCode fireButton;
    public float bowVelocity;

    public Transform spawn; // arrow spawn position
    public Rigidbody2D arrowObj; // arrow projectile object.

    // These bools control AimAssist and arrowhead rotation.
    public bool arrowFired = false;
    public bool aimAssist = false;

    Vector3 player_pos;

    private void Start()
    {
        bowVelocity = 11.3F;
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        BowLoad();
        BowShoot();
    }

    void BowLoad()
    {

    }

    // Fetches mouse position to figure out angle at which 
    void BowShoot()
    {
        Vector2 mouse_pos = Input.mousePosition;
        player_pos = Camera.main.WorldToScreenPoint(this.transform.position);
        player_pos.z = 0.0f;

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0))
        {
            arrowFired = false;
            aimAssist = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Rigidbody2D arrow = Instantiate(arrowObj, spawn.transform.position, Quaternion.Euler(new Vector3(0, 0, angle))) as Rigidbody2D;
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

            arrow.velocity = dir*bowVelocity ;
            arrow.bodyType = RigidbodyType2D.Dynamic;
            arrow.mass = 1.0F;
            arrow.angularDrag = 0.0F;
            arrow.drag = 0.0F;

            //arrow.transform.right = Vector3.Slerp(this.transform.right, this.GetComponent<Rigidbody2D>().velocity.normalized, Time.deltaTime);

            aimAssist = false;
            arrowFired = true;
        }
    }

    void ArrowTrajectory()
    {

    }
}
