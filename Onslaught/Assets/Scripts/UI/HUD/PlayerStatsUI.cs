using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    PlayerStats pStats;
    GameController gController;

    public Text nameUI;
    public Text levelUI;
    public Text curExpUI;
    public Text curDamageUI;
    public Text curHealthUI;
    public Text curMagicUI;
    public Text waveNumberUI;
    public Text enemyCountUI;
    
    void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        gController = GameObject.Find("GameController").GetComponent<GameController>();

    }

    void Update()
    {
        nameUI.text = pStats.userName;
        levelUI.text = "LEVEL:" + pStats.level;
        curExpUI.text = "EXP: " + pStats.curExp.ToString();
        curDamageUI.text = "DAMAGE: " + pStats.curDamage.ToString();
        curHealthUI.text = "HEALTH: " + pStats.curHealth.ToString() + " / " + pStats.maxHealth.ToString();
        curMagicUI.text = "MAGIC: " + pStats.curMagic.ToString() + " / " + pStats.maxMagic.ToString();
        waveNumberUI.text = "WAVE: " + gController.waveNumber.ToString();
        enemyCountUI.text = gController.enemiesAlive.ToString() + " ORCS ALIVE";
    }
}