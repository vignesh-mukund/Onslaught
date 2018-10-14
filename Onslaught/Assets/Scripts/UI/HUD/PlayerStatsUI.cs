using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    PlayerStats pStats;

    public Text nameUI;
    public Text curExpUI;
    public Text curDamageUI;
    public Text curHealthUI;
    
    void Start()
    {
        pStats = GameObject.Find("Archer").GetComponent<PlayerStats>();
    }

    void Update()
    {
        nameUI.text = pStats.userName;
        curExpUI.text = "Exp: " + pStats.curExp.ToString();
        curDamageUI.text = "Damage: " + pStats.curDamage.ToString();
        curHealthUI.text = "Health: " + pStats.curHealth.ToString();
    }
}