using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UnitSelection : MonoBehaviour,  IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    public string id;
    public Image image;
    public bool unlock;

    public UnitStats unitStats;


    private Fraction playerFraction;

    public GameObject meleeSelected;
    public GameObject rangeSelected;
    public GameObject tankSelected;
    public GameObject healerSelected;


    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        image.sprite = unitStats.unitSplashArt;
        findPlayerFraction();

        setSelectedPositions();


    }


    private void setSelectedPositions()
    {
        if(unitStats == playerFraction.meleeUnit)
        {
            transform.SetParent(meleeSelected.transform);
        }

        if (unitStats == playerFraction.rangeUnit)
        {
            transform.SetParent(rangeSelected.transform);
        }

        if (unitStats == playerFraction.tankUnit)
        {
            transform.SetParent(tankSelected.transform);
        }
        if (unitStats == playerFraction.healerUnit)
        {
            transform.SetParent(healerSelected.transform);
        }
    }


    private void findPlayerFraction()
    {
        playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();
        if (!playerFraction) throw new System.Exception("Missing player fraction object!");
    }

    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if(playerFraction == null)
        {
            findPlayerFraction();
        }


        foreach (UnitStats unit in playerFraction.availbleUnits)
        {
            if (unit == unitStats)
            {
                unlock = true;
                break;
            }
        }

        if (unlock)
        {
            canvasGroup.alpha = 1f;
        }
        else
        {
            canvasGroup.alpha = 0.2f;
        }
    }
  

    public void OnBeginDrag(PointerEventData eventData)
    {
       if(unlock==true)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
       

        

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (unlock == true)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (unlock == true)
        {
            transform.SetParent(parentAfterDrag);
            image.raycastTarget = true;
        }
    }




 
}
