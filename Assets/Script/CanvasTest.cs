using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTest : MonoBehaviour
{
    public GameObject canvasA; 
    public GameObject canvasB; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canvasA != null)
                canvasA.SetActive(true);
            if (canvasB != null)
                canvasB.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (canvasA != null)
                canvasA.SetActive(false);
            if (canvasB != null)
                canvasB.SetActive(true);
        }
    }
}
