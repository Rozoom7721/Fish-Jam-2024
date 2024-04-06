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

    public GameObject noUnitAlert;


    public Fraction enemyFraction;

    private bool canAttack;

    private void OnEnable()
    {
        Fraction playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();

        if(playerFraction.meleeUnit == null || playerFraction.rangeUnit == null || playerFraction.tankUnit == null || playerFraction.healerUnit == null)
        {
            canAttack = false;
            noUnitAlert.SetActive(true);
        }
        else
        {
            canAttack = true;
            noUnitAlert.SetActive(false);
        }
    }

    public void Attack()
    {
        if (canAttack == false) return;

        GameObject enemy = new GameObject("enemy");
        enemy.tag = "Enemy";
        Fraction enemyFractionComponent = enemy.AddComponent<Fraction>();
        enemyFractionComponent.CopyFrom(enemyFraction);

        DontDestroyOnLoad(enemy);

        SceneManager.LoadScene("SampleScene");
    }
}
