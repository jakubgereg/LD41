using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public static GameObject itemDragged;
    private Vector3 startPosition;
    private Transform startParent;

    public GameObject toSpawn;


    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        transform.position = Input.mousePosition;
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        itemDragged = null;
        //GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        startParent = null;
        transform.position = eventData.position;


        //how far you are dropping it
        var distance = Mathf.Abs(transform.position.y - startPosition.y);

        Debug.Log(distance);

        if (distance < 50)
        {
            transform.position = startPosition;
            return;
        }


        var pos = Camera.main.ScreenToWorldPoint(eventData.position);

        Vector3 newpost = new Vector3(pos.x, pos.y, 1);

        toSpawn.transform.position = newpost;

        toSpawn.SetActive(true);

        Instantiate(toSpawn);
        Destroy(gameObject);
    }
}
