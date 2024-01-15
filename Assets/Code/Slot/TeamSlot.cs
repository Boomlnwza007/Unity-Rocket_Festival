using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeamSlot : MonoBehaviour ,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableSlot draggableSlot = dropped.GetComponent<DraggableSlot>();
        draggableSlot.parentAfterDeag = transform;
    }

}
