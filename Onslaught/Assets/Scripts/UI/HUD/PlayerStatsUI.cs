using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    PlayerStats pStats;
    GameController gController;

    public Text nameUI;
    public Text curExpUI;
    public Text curDamageUI;
    public Text curHealthUI;
    public Text waveNumberUI;
    
    void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
        gController = GameObject.Find("GameController").GetComponent<GameController>();

    }

    void Update()
    {
        nameUI.text = pStats.userName;
        curExpUI.text = "Level:" + pStats.level + "/ Exp: " + pStats.curExp.ToString();
        curDamageUI.text = "Damage: " + pStats.curDamage.ToString();
        curHealthUI.text = "Health: " + pStats.curHealth.ToString();
        waveNumberUI.text = "Wave: " + gController.waveNumber.ToString();
    }
}