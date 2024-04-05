using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFraction : MonoBehaviour
{
    public Image unit1;
    public Image unit2;
    public Image unit3;
    public Image unit4;
    public Image herb;
    public void Attack()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
