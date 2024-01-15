using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableSlot : MonoBehaviour , IBeginDragHandler ,IDragHandler ,IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDeag;
    private RectTransform rectTransform;
    public Image image;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();    
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        parentAfterDeag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Color c = image.color;
        c.a = 0.5f;
        image.color = c;
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ON");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        transform.SetParent(parentAfterDeag);
        image.raycastTarget = true;
        Color c = image.color;
        c.a = 1f;
        image.color = c;
    }

}
