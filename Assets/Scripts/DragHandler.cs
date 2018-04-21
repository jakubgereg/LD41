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
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }


    //this is not working as i wanted when camera is moving grid is useless
    private Vector3 XConvertToGridPosition(Vector3 input)
    {
        Vector3 result;
        int size = 35;


        var new_x = Mathf.Round(input.x / size);
        var new_y = Mathf.Round(input.y / size);



        result = new Vector3(new_x * size, new_y * size, input.z);


        Debug.Log(result);
        return result;

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        itemDragged = null;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        startParent = null;
        transform.position = eventData.position;


        //how far you are dropping it
        var distance = Mathf.Abs(transform.position.y - startPosition.y);

        if (distance < 50)
        {
            transform.position = startPosition;
            return;
        }

        var np = eventData.position;

        var pos = Camera.main.ScreenToWorldPoint(np);

        Vector3 newpost = new Vector3(pos.x, pos.y, 1);

        toSpawn.transform.position = newpost;

        toSpawn.SetActive(true);

        Instantiate(toSpawn);
        Destroy(gameObject);
    }
}
