using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Projectile : MonoBehaviour
{ 

    public GameObject arrow;
    public Vector3 player_pos;

    PlayerController pC;

    [Tooltip("Position we want to hit")]
    public Vector3 targetPos;

    [Tooltip("Horizontal speed, in units/sec")]
    public float speed = 10;

    [Tooltip("How high the arc should be, in units")]
    public float arcHeight = 1;

    public float chargedPower;
    private bool aimAssist;
    private bool isArrowLoaded;
    private bool aimReady;
    private bool arrowShot;

    Vector3 startPos;

    void Start()
    {
        // Cache our start position, which is really the only thing we need
        // (in addition to our current position, and the target).
        startPos = transform.position;
        chargedPower = 0.0F;
        isArrowLoaded = false;
        aimAssist = false;
        aimReady = false;
        arrowShot = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aimAssist = true;
            Debug.Log("Left mouse button pressed");

            chargedPower += 25 * Time.deltaTime;
            if (chargedPower >= 100)
            {
                chargedPower = 100;
            }
            aimReady = true;
        }
        if (aimAssist == true)
        {
            Vector3 mouse_pos = Input.mousePosition;
            player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

            mouse_pos.x = mouse_pos.x - player_pos.x;
            mouse_pos.y = mouse_pos.y - player_pos.y;

            float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (aimReady && Input.GetMouseButtonUp(1))
        {
            Debug.Log("Arrow Shot!");
            Debug.Log(chargedPower);
            ShootArrow();
            arrowShot = true;
            chargedPower = 0.0F;
            aimAssist = false;
            aimReady = false;
        }
        if (arrowShot && Time.deltaTime >= 4)
        {
            Destroy(this.gameObject);
        }

    }

    void FixedUpdate()
    {
    }



    // This function calculates how far the bowstring has been pulled to find out the power with which the arrow will be shot out.
    void ChargeUp()
    {
    }

    // This function notes the power and angle and shoots the arrow on buttonUp.
    void ShootArrow()
    {
        Rigidbody2D arrowCloneRb = arrow.GetComponent<Rigidbody2D>();
        
        arrowCloneRb.AddForce(transform.right * 10 * chargedPower, ForceMode2D.Impulse);


        // Compute the next position, with arc added in
        /* float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
        Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);
        


        // Rotate to face the next position, and then move there
        transform.rotation = LookAt2D(nextPos - transform.position);
        transform.position = nextPos;

        // Do something when we reach the target
        if (nextPos == targetPos) Arrived();
*/
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name == "Ground")
        {
            Destroy(this.gameObject);
            pC.isArrowLoaded = false;
        }
        if (col.gameObject.name == "Home Tower")
        {
            Destroy(this.gameObject);
            pC.isArrowLoaded = false;
        }
    }

    /// 
    /// This is a 2D version of Quaternion.LookAt; it returns a quaternion
    /// that makes the local +X axis point in the given forward direction.
    /// 
    /// forward direction
    /// Quaternion that rotates +X to align with forward
    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}
