using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGrounded = false;
    private float distanceFromGround = .3f;
    public LayerMask layer;

    private void FixedUpdate()
    {
        IsGrounded = CheckIsGrounded();
    }

    public bool CheckIsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = distanceFromGround;



        Debug.DrawRay(position, direction, Color.green);

        //RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, layer);
        RaycastHit2D hit = Physics2D.BoxCast(position, new Vector2(0.5f, 1f), 0f, direction, distance, layer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
