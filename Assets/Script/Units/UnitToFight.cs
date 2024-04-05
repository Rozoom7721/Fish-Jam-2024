using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitToFight : MonoBehaviour, IDropHandler
{
    public string allowedItemType;
    public int idSlot;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            UnitSelection draggableItem = dropped.GetComponent<UnitSelection>();
            // draggableItem.parentAfterDrag = transform;
            if (draggableItem != null && draggableItem.tag == allowedItemType)
            {
                draggableItem.parentAfterDrag = transform;
            }
            UnitList.unitToFight[idSlot]= draggableItem.id;
        }


    }
}
