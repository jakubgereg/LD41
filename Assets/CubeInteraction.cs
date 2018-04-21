using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public SpriteRenderer _spriteRenderer;
    public Rigidbody2D rigidbody2D;


    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("start");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("enter");
        rigidbody2D.AddForce(Vector2.left * 100, ForceMode2D.Force);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {


        _spriteRenderer.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _spriteRenderer.color = Color.white;
    }
}
