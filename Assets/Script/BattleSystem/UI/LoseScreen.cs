using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public void onClick()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        SceneManager.MoveGameObjectToScene(enemy, SceneManager.GetActiveScene());

        SceneManager.LoadScene("mapa_mati");

    }


}
