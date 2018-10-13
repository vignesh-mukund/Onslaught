using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ProjectileArcRenderer : MonoBehaviour {

    LineRenderer lr;
    BowBehaviour bBehaviour;
    PlayerController pController;

    Vector3 player_pos;
    float velocity = 12.5F;
    float angle = 0;
    public int resolution = 70;

    float g;
    float radianAngle;
    bool isAiming = false;

    void Awake ()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }
    
    void Start ()
    {
        bBehaviour = GameObject.Find("Bow").GetComponent<BowBehaviour>();
        pController = GameObject.Find("Archer").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (pController.isActive == PlayerController.ActiveAttack.None)
        { 
            if (Input.GetMouseButtonDown(0) && bBehaviour.canShoot)
            {
                isAiming = true;
                lr.enabled = true;
            }
            if (isAiming)
            {
                Vector3 mouse_pos = Input.mousePosition;
                player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

                mouse_pos.x = mouse_pos.x - player_pos.x;
                mouse_pos.y = mouse_pos.y - player_pos.y;

                angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
                //this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                RenderArc();
            }
            if (Input.GetMouseButtonUp(0))
            {
                lr.enabled = false;
                isAiming = false;
            }
        }
    }

    void RenderArc ()
    {
        lr.positionCount = resolution + 1 ;
        lr.SetPositions (CalculateArcArray());
    }

    Vector3[] CalculateArcArray ()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;

        float maxDistance = ((velocity * Mathf.Cos(radianAngle) / g) * ((velocity * Mathf.Sin(radianAngle)) + Mathf.Sqrt((velocity * Mathf.Sin(radianAngle) * Mathf.Sin(radianAngle)) + (2 * g * 15))));

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }

        return arcArray;
    }

    Vector3 CalculateArcPoint (float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - (g * x * x / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));

        return new Vector3(x, y);
    }
} 
