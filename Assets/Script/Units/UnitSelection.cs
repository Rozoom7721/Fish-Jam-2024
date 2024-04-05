using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UnitSelection : MonoBehaviour,  IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    public int id;
    public Image image;
    public bool unlock;

   [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
   


    }
    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        foreach (int num in UnitList.unit)
        {
            if (num == id)
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
