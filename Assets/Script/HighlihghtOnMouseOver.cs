using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighlihghtOnMouseOver : MonoBehaviour
{
    public Sprite startSprie;
    public Sprite endSprie;

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = endSprie; // Ustaw kolor pod�wietlenia
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = startSprie; // Przywr�� oryginalny kolor
    }
    private void OnMouseDown()
    {
        
    }
}
