using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public PlayerStats Player;

    [SerializeField]
    public Canvas skillCanvas;
    private bool seeCanvas;

    private void Start()
    {
        skillCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if(skillCanvas)
            {
                Debug.Log("UI toggled");
                seeCanvas = !seeCanvas;
                skillCanvas.gameObject.SetActive(seeCanvas);
            }
        }
    }
}
