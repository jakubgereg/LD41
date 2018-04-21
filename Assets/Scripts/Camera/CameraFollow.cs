using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    public GameObject ToFollow;
    public float FollowSpeed = 4f;
    public float MoveOffset = .8f;

    public float constOffsetX = 0f;
    public float constOffsetY = 0f;

    private Camera _cam;
    private bool _inMove = false;

    private void Start()
    {
        _cam = GetComponent<Camera>();
    }


    private void FixedUpdate()
    {
        if (_cam & ToFollow)
        {

            var toFollowPos = ToFollow.transform.position;
            var camPos = _cam.transform.position;

            var dist = Vector2.Distance(camPos, toFollowPos);
            if (dist <= 0.1f)
            {
                _inMove = false;
            }

            if ((dist > MoveOffset) || _inMove)
            {
                _inMove = true;
                var targetPos = new Vector3(toFollowPos.x + constOffsetX, toFollowPos.y + constOffsetY, camPos.z);
                _cam.transform.position = Vector3.Lerp(camPos, targetPos, FollowSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
