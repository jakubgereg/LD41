using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //TODO implement breaks to have more realistics movement
    private Rigidbody2D _rigid2d;

    [Range(.5f, 2f)]
    public float MovementSpeed = 1f;

    public float JumpHeight = 1f;

    public bool isGrounded = false;

    private float minSpeed = 0.5f;
    private float maxSpeedX = 8f;
    private float maxSpeedY = 10f;


    void Start()
    {
        _rigid2d = GetComponent<Rigidbody2D>();

    }

    //error here in detecting ground :(

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
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

        Vector2 movement = new Vector2(h, 0f);

        SetMinMaxVelocity(movement);

        //Debug.Log(_rigid2d.velocity.x);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;

            _rigid2d.velocity = new Vector2(_rigid2d.velocity.x, JumpHeight);
        }

    }

    private void SetMinMaxVelocity(Vector2 movement)
    {
        if (Mathf.Abs(_rigid2d.velocity.y) > maxSpeedY)
        {
            var mrClaper = Mathf.Clamp(_rigid2d.velocity.y, -maxSpeedY, maxSpeedY);
            _rigid2d.velocity = new Vector2(_rigid2d.velocity.x, mrClaper);
        }


        if (Mathf.Abs(_rigid2d.velocity.x) > maxSpeedX)
        {
            var mrClaper = Mathf.Clamp(_rigid2d.velocity.x, -maxSpeedX, maxSpeedX);
            _rigid2d.velocity = new Vector2(mrClaper, _rigid2d.velocity.y);
        }
        else
        {
            _rigid2d.AddForce(movement * MovementSpeed * 10f);
        }
    }
}
