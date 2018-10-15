using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    PlayerStats pStats;
    //PlayerSkillMap pSkillMap;

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
       // pSkillMap = GameObject.Find("Archer").GetComponent<PlayerSkillMap>();

        isActive = ActiveAttack.None;
        spell1CDTimer = 0.0f;
        spell2CDTimer = 0.0f;
		
	}

    // Update is called once per frame
    void Update()
    {

        if (darkenTheSkiesSpell.spellLevel >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (pStats.curMagic - darkenTheSkiesSpell.magicRequired >= 0)
                {
                    if (Time.time > spell1CDTimer)
                    {
                        isActive = ActiveAttack.Spell1;
                    }
                    else
                    {
                        Debug.Log(spell1CDTimer - Time.time + " seconds remaining.");
                    }
                }
                else
                {
                    Debug.Log("Insufficient Magic");
                    return;
                }
            }
        }

        if (headShotSpell.spellLevel >= 1)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (pStats.curMagic - headShotSpell.magicRequired >= 0)
                {
                    if (Time.time > spell2CDTimer)
                    {
                        isActive = ActiveAttack.Spell2;
                    }
                    else
                    {
                        Debug.Log(spell2CDTimer - Time.time + " seconds remaining.");
                    }
                }
                else
                {
                    Debug.Log("Insufficient Magic");
                    return;
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
    
    public void ActivateSkill(ActiveSpell spell)
    {
        if (spell == darkenTheSkiesSpell)
        {
            if (pStats.curMagic - darkenTheSkiesSpell.magicRequired >= 0)
            {
                if (Time.time > spell1CDTimer)
                {
                    isActive = ActiveAttack.Spell1;
                }
                else
                {
                    Debug.Log(spell1CDTimer - Time.time + " seconds remaining.");
                }
            }
            else
            {
                Debug.Log("Insufficient Magic");
                return;
            }
        }
        else if (spell == headShotSpell)
        {
            if (pStats.curMagic - headShotSpell.magicRequired >= 0)
            {
                if (Time.time > spell2CDTimer)
                {
                    isActive = ActiveAttack.Spell2;
                }
                else
                {
                    Debug.Log(spell2CDTimer - Time.time + " seconds remaining.");
                }
            }
            else
            {
                Debug.Log("Insufficient Magic");
                return;
            }
        }

    }
}
