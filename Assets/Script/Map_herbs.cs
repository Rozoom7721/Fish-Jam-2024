using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_herbs : MonoBehaviour
{
    public Canvas canvas; // Referencja do obiektu Canvas, który chcesz w³¹czyæ

    public void OpenFraction()
    {
        canvas.gameObject.SetActive(true);
    }
    
}
