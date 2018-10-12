using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool isArrowLoaded;
    private Projectile arrow;

	// Use this for initialization
	void Start () {

        isArrowLoaded = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isArrowLoaded)
        {
        }
        if (!isArrowLoaded)
        {

        }
		
	}
}
