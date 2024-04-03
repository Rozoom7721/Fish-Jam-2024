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
        GetComponent<SpriteRenderer>().sprite = endSprie; // Ustaw kolor podœwietlenia
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = startSprie; // Przywróæ oryginalny kolor
    }
    private void OnMouseDown()
    {
        
    }
}
