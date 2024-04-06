using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public string allowedItemType;

    [SerializeField]
    private Fraction playerFraction;

    private void Start()
    {
        playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();
        if (!playerFraction) throw new System.Exception("Missing player fraction object!");
    }

    public void OnDrop(PointerEventData eventData)
    {

        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            UnitSelection draggableItem = dropped.GetComponent<UnitSelection>();
           // draggableItem.parentAfterDrag = transform;
            if (draggableItem != null && draggableItem.tag == allowedItemType)
            {
                playerFraction.unselectUnit(draggableItem.id);
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
