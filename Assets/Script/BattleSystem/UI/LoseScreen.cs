using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("mapa_mati");
    }


}
