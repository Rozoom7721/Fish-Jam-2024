using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighlihghtOnMouseOver : MonoBehaviour
{
    public Sprite startSprie;
    public Sprite endSprie;
    public Castle castle;
    public Description description;

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = endSprie; // Ustaw kolor pod�wietlenia
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = startSprie; // Przywr�� oryginalny kolor
    }
    public void OnMouseDown()
    {
        
        castle.SpriteChange();
        description.ChangeDesc();
    }

}
