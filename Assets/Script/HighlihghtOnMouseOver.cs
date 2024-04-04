using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighlihghtOnMouseOver : MonoBehaviour
{
    public Sprite startSprie;
    public Sprite endSprie;
    public Canvas openCanvas;

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = endSprie; // Ustaw kolor podœwietlenia
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = startSprie; // Przywróæ oryginalny kolor
    }
    public void OnMouseDown()
    {
        OpenFraction();
    }
    public void OpenFraction()
    {
        openCanvas.gameObject.SetActive(true);
    }
}
