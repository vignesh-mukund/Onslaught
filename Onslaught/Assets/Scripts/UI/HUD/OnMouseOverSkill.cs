using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnMouseOverSkill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Text descriptionText;

    public Spell spell;

    private void Start()
    {
        //descriptionText = this.gameObject.GetComponent<Text>();
        descriptionText.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionText.text = spell.skillDescription;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionText.text = "";
    }

}
