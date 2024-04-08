using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    private Sprite unit1;
    private Sprite unit2;
    private Sprite unit3;
    private Sprite unit4;
    public Sprite herb;
    public MenuFraction menuFraction;
    public GameObject map;

    private Fraction enemyFraction;

    public int levelId;


    public GameObject starTier1;
    public GameObject starTier2;
    public GameObject starTier3;
    public GameObject starTier4;

    private void Start()
    {

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>().levelsDone.Contains(levelId))
        {
            Destroy(gameObject);
        }

        enemyFraction = GetComponent<Fraction>();

        unit1 = enemyFraction.meleeUnit.unitSplashArt;
        unit2 = enemyFraction.rangeUnit.unitSplashArt;
        unit3 = enemyFraction.tankUnit.unitSplashArt;
        unit4 = enemyFraction.healerUnit.unitSplashArt;


        switch(enemyFraction.skillTier)
        {
            case 1:
                {
                    starTier1.SetActive(true);
                    starTier2.SetActive(false);
                    starTier3.SetActive(false);
                    starTier4.SetActive(false);

                    break;
                }
            case 2:
                {
                    starTier1.SetActive(false);
                    starTier2.SetActive(true);
                    starTier3.SetActive(false);
                    starTier4.SetActive(false);



                    break;
                }
            case 3:
                {
                    starTier1.SetActive(false);
                    starTier2.SetActive(false);
                    starTier3.SetActive(true);
                    starTier4.SetActive(false);


                    break;
                }
            case 4:
                {
                    starTier1.SetActive(false);
                    starTier2.SetActive(false);
                    starTier3.SetActive(false);
                    starTier4.SetActive(true);

                    break;
                }
        }

    }


    public void SpriteChange()
    {
        menuFraction.gameObject.SetActive(true);
        menuFraction.enemyFraction = enemyFraction;
        map.SetActive(false);
        
        menuFraction.unit1.sprite = unit1;
        menuFraction.unit2.sprite = unit2;
        menuFraction.unit3.sprite = unit3;
        menuFraction.unit4.sprite = unit4;
        menuFraction.herb.sprite = herb;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>().lastLevelId = levelId;

    }
}
