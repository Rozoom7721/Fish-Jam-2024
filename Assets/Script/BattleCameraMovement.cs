using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraMovement : MonoBehaviour
{
    public float scrollSpeed = 5f; // Pr�dko�� przesuwania kamery
    public Transform leftLimit; // Ogranicznik lewej kraw�dzi
    public Transform rightLimit; // Ogranicznik prawej kraw�dzi

    void Update()
    {
        // Sprawd� pozycj� myszy na osi X
        float mouseXPosition = Input.mousePosition.x;

        // Sprawd� czy myszka znajduje si� przy lewej lub prawej kraw�dzi ekranu
        if (mouseXPosition <= 0) // Lewa kraw�d�
        {
            MoveCamera(-1); // Przesu� kamer� w lewo
        }
        else if (mouseXPosition >= Screen.width - 1) // Prawa kraw�d� (Screen.width - 1 ze wzgl�du na brzeg piksela)
        {
            MoveCamera(1); // Przesu� kamer� w prawo
        }
    }

    void MoveCamera(int direction)
    {
        // Oblicz przesuni�cie kamery na osi X
        float displacement = scrollSpeed * direction * Time.deltaTime;

        // Sprawd� czy przesuni�cie nie spowoduje wyj�cia poza ograniczniki
        if ((direction < 0 && transform.position.x > leftLimit.position.x) ||
            (direction > 0 && transform.position.x < rightLimit.position.x))
        {
            // Przesu� kamer�
            transform.Translate(new Vector3(displacement, 0, 0));
        }
    }
}
