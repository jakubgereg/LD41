using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraStill : MonoBehaviour
{

    public GameObject FocusOn;

    public float constOffsetX;
    public float constOffsetY;

    private Camera _cam;

    void Start()
    {
        Reposition();
    }

    void Reposition()
    {
        _cam = GetComponent<Camera>();

        if (_cam)
        {
            var camPos = _cam.transform.position;

            var toFocus = FocusOn.transform.position;
            var targetPos = new Vector3(toFocus.x + constOffsetX, toFocus.y + constOffsetY, camPos.z);

            _cam.transform.position = targetPos;
        }
    }

    private void OnEnable()
    {
        Reposition();
    }


}
