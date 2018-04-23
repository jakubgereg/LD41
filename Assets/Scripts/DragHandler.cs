using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IPointerClickHandler
{
    public static GameObject UIObject;

    private Vector3 startPosition;

    private Transform startParent;

    public GameObject toSpawn;
    public GameObject PlatformerPlacing;

    private AudioManager _am;

    public bool IsSelected = false;
    public bool IsPlaced = false;

    void Start()
    {
        _am = FindObjectOfType<AudioManager>();
        startPosition = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (!IsSelected)
        {
            IsSelected = true;
            if (!PlatformerPlacing)
                PlatformerPlacing = InstantianteGameObject(startPosition);

            var platformPlacer = PlatformerPlacing.GetComponent<PlatformPlacer>();

            if (IsPlaced)
            {
                IsPlaced = false;
                platformPlacer.IsPlaced = false;
            }
            platformPlacer.OnPlatformPlacer += DragHandler_OnPlatformPlacer;

        }
        else
        {
            IsSelected = false;
            IsPlaced = false;
        }
    }

    private void DragHandler_OnPlatformPlacer()
    {
        Debug.Log("placing");
        SetPlatformerPlaced();
    }

    private void SetPlatformerPlaced()
    {
        IsSelected = false;
        IsPlaced = true;
        PlatformerPlacing.GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update()
    {
        if (IsSelected & !IsPlaced)
        {
            var mousePos = Input.mousePosition;
            PlatformerPlacing.transform.position = XConvertToGridPosition(mousePos);
        }

    }



    ////origin needs to be world position
    private GameObject InstantianteGameObject(Vector2 origin)
    {
        //disable boxCollider if not placed
        toSpawn.GetComponent<BoxCollider2D>().enabled = false;
        toSpawn.transform.position = origin;
        toSpawn.SetActive(true);
        return Instantiate(toSpawn);
    }

    //private Vector3 GetWorldPosition(Vector2 origin)
    //{
    //    var pos = Camera.main.ScreenToWorldPoint(origin);
    //    Vector3 newpost = new Vector3(pos.x, pos.y, -1);

    //    return newpost;
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    itemDragged = toSpawn;


    //    startPosition = transform.position;
    //    startPostWorld = GetWorldPosition(transform.position);

    //    placing = InstantianteGameObject(startPostWorld);
    //    placing_color = placing.GetComponent<SpriteRenderer>().color;

    //    startParent = transform.parent;
    //}

    //private bool IsPlacible()
    //{
    //    var distance = placing.transform.position.y - startPostWorld.y;

    //    if (distance > -1f)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }


    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    placing.transform.position = XConvertToGridPosition(Input.mousePosition);
    //}

    ////this is not working as i wanted when camera is moving grid is useless
    private Vector3 XConvertToGridPosition(Vector3 input)
    {
        Vector3 result;

        var wp = Camera.main.ScreenToWorldPoint(input);

        result = new Vector3(wp.x, wp.y, -1);

        return result;

    }


    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    itemDragged = null;

    //    var distance = placing.transform.position.y - startPostWorld.y;

    //    //0 1 2 if you cannot place it
    //    if (!IsPlacible())
    //    {
    //        Destroy(placing);
    //        placing = null;
    //        //_as.clip = failPick;
    //        _am.PlaySound(_am.failerPlacedBox);
    //        //destroy object
    //    }
    //    else
    //    {
    //        if (transform.parent == startParent)
    //        {
    //            transform.position = startPosition;
    //        }
    //        placing.GetComponent<BoxCollider2D>().enabled = true;

    //        //_as.clip = succesPick;
    //        _am.PlaySound(_am.succesPlacedBox);

    //        Destroy(gameObject);
    //    }

    //}


    ////hm not using this one
    //public void POnDrop(PointerEventData eventData)
    //{
    //    startParent = null;
    //    placing.transform.position = eventData.position;


    //    //how far you are dropping it
    //    var distance = Mathf.Abs(placing.transform.position.y - startPosition.y);

    //    if (distance < 50)
    //    {
    //        Debug.Log("destroy");
    //        placing.transform.position = startPosition;
    //        Destroy(placing);
    //        return;
    //    }

    //    //var np = eventData.position;



    //    Destroy(gameObject);
    //}
}
