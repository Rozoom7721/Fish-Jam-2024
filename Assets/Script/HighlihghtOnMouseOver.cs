using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HighlihghtOnMouseOver : MonoBehaviour
{
    public Sprite startSprie;
    public Sprite endSprie;
    public Castle castle;
    public Description description;
    public SoundPlay soundPlayer;

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
        soundPlayer.playThisSoundEffect();
        
    }

}
