using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public string allowedItemType;

    public void OnDrop(PointerEventData eventData)
    {

        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            UnitSelection draggableItem = dropped.GetComponent<UnitSelection>();
           // draggableItem.parentAfterDrag = transform;
            if (draggableItem != null && draggableItem.tag == allowedItemType)
            {
                draggableItem.parentAfterDrag = transform; 
            }


            Debug.LogWarning("Fix Me 2!");
/*            if (draggableItem.id == 1)
            {
                Debug.Log("typ 1");
            }*/
        }
      

    }


}
