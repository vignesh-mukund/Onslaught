using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkillBar : MonoBehaviour {

    PlayerController pController;
    PlayerStats pStats;
    PlayerSkillMap pSkillMap;

    public Button skill1, skill2;
    public Button levelSkill1, levelSkill2, levelSkill3, levelSkill4;

    public Text skill1Name, skill2Name, skill3Name, skill4Name;

    public Text skill1LevelUpText, skill2LevelUpText, skill3LevelUpText, skill4LevelUpText;

    public Text skill1LevelText, skill2LevelText, skill3LevelText, skill4LevelText;
    

    public DarkenTheSkies darkenTheSkies;
    public HeadShot headShot;
    public Fortify fortify;
    public ImprovedArrows improvedArrows;
    
	void Start ()
    {
        pController = GameObject.Find("Archer").GetComponent<PlayerController>();
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        pSkillMap = GameObject.Find("Archer").GetComponent<PlayerSkillMap>();

        skill1 = skill1.GetComponent<Button>();
        skill2 = skill2.GetComponent<Button>();
        levelSkill1 = levelSkill1.GetComponent<Button>();
        levelSkill2 = levelSkill2.GetComponent<Button>();
        levelSkill3 = levelSkill3.GetComponent<Button>();
        levelSkill4 = levelSkill4.GetComponent<Button>();

        skill1.onClick.AddListener(delegate { pController.ActivateSkill(darkenTheSkies);  });
        skill2.onClick.AddListener(delegate { pController.ActivateSkill(headShot);  });

        levelSkill1.onClick.AddListener(delegate { LevelUpSkill(darkenTheSkies);  });
        levelSkill2.onClick.AddListener(delegate { LevelUpSkill(headShot);  });
        levelSkill3.onClick.AddListener(delegate { LevelUpSkill(fortify);  });
        levelSkill4.onClick.AddListener(delegate { LevelUpSkill(improvedArrows);  });

        skill1.interactable = false;
        skill2.interactable = false;

        levelSkill1.interactable = false;
        levelSkill2.interactable = false;
        levelSkill3.interactable = false;
        levelSkill4.interactable = false;

        skill1Name.text = "Darken The Skies";
        skill2Name.text = "Headshot";
        skill3Name.text = "Fortify";
        skill4Name.text = "Improved Arrows";

        skill1LevelText.text = darkenTheSkies.spellLevel.ToString();
        skill2LevelText.text = headShot.spellLevel.ToString();
        skill3LevelText.text = fortify.spellLevel.ToString();
        skill4LevelText.text = improvedArrows.spellLevel.ToString();


        skill1LevelUpText.text = pStats.unspentSkillPoints.ToString();
        skill2LevelUpText.text = pStats.unspentSkillPoints.ToString();
        skill3LevelUpText.text = pStats.unspentSkillPoints.ToString();
        skill4LevelUpText.text = pStats.unspentSkillPoints.ToString();

    }
    
    void Update()
    {
        if (darkenTheSkies.spellLevel >= 1)
        {
            skill1.interactable = true;

        }

        if (headShot.spellLevel >= 1)
        {
            skill2.interactable = true;

        }

        if (pStats.unspentSkillPoints >= 1)
        {
            StartCoroutine(UnspentSkillPoints());
        }
        else return;

       
        StartCoroutine(UpdateSkillInfo());
    }

    IEnumerator UnspentSkillPoints()
    {
        while (pStats.unspentSkillPoints >= 1)
        {
            levelSkill1.interactable = true;
            levelSkill2.interactable = true;
            levelSkill3.interactable = true;
            levelSkill4.interactable = true;
            yield return null;
        }
        if(pStats.unspentSkillPoints < 1)
        {
            skill1LevelUpText.text = pStats.unspentSkillPoints.ToString();
            skill2LevelUpText.text = pStats.unspentSkillPoints.ToString();
            skill3LevelUpText.text = pStats.unspentSkillPoints.ToString();
            skill4LevelUpText.text = pStats.unspentSkillPoints.ToString();

            levelSkill1.interactable = false;
            levelSkill2.interactable = false;
            levelSkill3.interactable = false;
            levelSkill4.interactable = false;
        }
    }

    void LevelUpSkill(Spell spell)
    {
        if (pStats.unspentSkillPoints - 1 >= 0)
        {
            pSkillMap.UpdateSkillMap(spell);
        }
    }

    IEnumerator UpdateSkillInfo()
    {
        while (true)
        {
            skill1LevelText.text = darkenTheSkies.spellLevel.ToString();
            skill2LevelText.text = headShot.spellLevel.ToString();
            skill3LevelText.text = fortify.spellLevel.ToString();
            skill4LevelText.text = improvedArrows.spellLevel.ToString();
            yield return null;
        }
    }
}
