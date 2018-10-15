using UnityEngine;

public class OnMouseOverClass : MonoBehaviour
{
    void OnMouseOver()
    {
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject.");
    }
}