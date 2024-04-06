using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitToFight : MonoBehaviour, IDropHandler
{
    public string allowedItemType;
    public int idSlot;

    [SerializeField]
    private Fraction playerFraction;

    private void Start()
    {
        playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();
        if (!playerFraction) throw new System.Exception("Missing player fraction object!");
    }


    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log("UnitToFight OnDrop");



        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            UnitSelection draggableItem = dropped.GetComponent<UnitSelection>();
            // draggableItem.parentAfterDrag = transform;
            if (draggableItem != null && draggableItem.tag == allowedItemType)
            {

                if (!isUnitUnlocked(draggableItem.id)) return;

                draggableItem.parentAfterDrag = transform;
                Debug.Log("UnitToFight.OnDrop:  id = " + draggableItem.id);
                playerFraction.SelectUnit(draggableItem.id);
            }

        }


    }


    public bool isUnitUnlocked(string unitID)
    {

        foreach (UnitStats unit in playerFraction.all_unit_types)
        {
            if (unit.unitId == unitID)
            {
                if (playerFraction.availbleUnits.Contains(unit))
                {
                    return true;
                }
            }
        }
        return false;

    }

}