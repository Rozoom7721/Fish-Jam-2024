using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraMovement : MonoBehaviour
{
    public float scrollSpeed = 5f; // Prêdkoœæ przesuwania kamery
    public Transform leftLimit; // Ogranicznik lewej krawêdzi
    public Transform rightLimit; // Ogranicznik prawej krawêdzi

    void Update()
    {
        // SprawdŸ pozycjê myszy na osi X
        float mouseXPosition = Input.mousePosition.x;

        // SprawdŸ czy myszka znajduje siê przy lewej lub prawej krawêdzi ekranu
        if (mouseXPosition <= 0) // Lewa krawêdŸ
        {
            MoveCamera(-1); // Przesuñ kamerê w lewo
        }
        else if (mouseXPosition >= Screen.width - 1) // Prawa krawêdŸ (Screen.width - 1 ze wzglêdu na brzeg piksela)
        {
            MoveCamera(1); // Przesuñ kamerê w prawo
        }
    }

    void MoveCamera(int direction)
    {
        // Oblicz przesuniêcie kamery na osi X
        float displacement = scrollSpeed * direction * Time.deltaTime;

        // SprawdŸ czy przesuniêcie nie spowoduje wyjœcia poza ograniczniki
        if ((direction < 0 && transform.position.x > leftLimit.position.x) ||
            (direction > 0 && transform.position.x < rightLimit.position.x))
        {
            // Przesuñ kamerê
            transform.Translate(new Vector3(displacement, 0, 0));
        }
    }
}
