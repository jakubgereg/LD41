using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //TODO implement breaks to have more realistics movement
    private Rigidbody2D _rigid2d;

    [Range(.5f, 2f)]
    public float MovementSpeed = 1f;

    public float JumpHeight = 1f;

    bool isGrounded = false;

    void Start()
    {
        _rigid2d = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var newh = Mathf.Clamp(h, -.7f, .7f);
        var newv = Mathf.Clamp(v, -.7f, .7f);

        Vector2 movement = new Vector2(newh, newv);

        _rigid2d.AddForce(movement * MovementSpeed * 10f);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;

            _rigid2d.velocity = new Vector2(_rigid2d.velocity.x, JumpHeight);
        }

    }
}
