using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    PlayerStats pStats;
    PlayerSkillMap pSkillMap;

    BowBehaviour bBehaviour;
    HeadShot headShotSpell;
    DarkenTheSkies darkenTheSkiesSpell;

    public bool isArrowLoaded;
    public enum ActiveAttack { None, Spell1, Spell2};
    public ActiveAttack isActive;

    public float spell1CDTimer, spell2CDTimer;

    
    void Start () {

        //bBehaviour = GameObject.Find("Bow").GetComponent<BowBehaviour>();
        headShotSpell = GameObject.Find("HeadShot").GetComponent<HeadShot>();
        darkenTheSkiesSpell = GameObject.Find("DarkenTheSkies").GetComponent<DarkenTheSkies>();
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        pSkillMap = GameObject.Find("Archer").GetComponent<PlayerSkillMap>();

        isActive = ActiveAttack.None;
        spell1CDTimer = 0.0f;
        spell2CDTimer = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(darkenTheSkiesSpell.spellLevel >= 1)
        {
            if (Time.time > spell1CDTimer)
            {
                if (Input.GetButton("Fire1"))
                {
                    isActive = ActiveAttack.Spell1;
                    spell1CDTimer = Time.time + darkenTheSkiesSpell.cooldown;
                }
            }
        }

        if (headShotSpell.spellLevel >= 1)
        {
            if (Time.time > spell2CDTimer)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    isActive = ActiveAttack.Spell2;
                    Debug.Log("DD");
                    spell2CDTimer = Time.time + headShotSpell.cooldown;
                }
            }
        }


        if(isActive == ActiveAttack.Spell1 || isActive == ActiveAttack.Spell2)
        {
            if ((Input.GetButton("Cancel")) || (Input.GetMouseButton(1)))
            {
                isActive = ActiveAttack.None;
            }
        }

    }
}
