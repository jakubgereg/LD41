using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //TODO implement breaks to have more realistics movement
    private Rigidbody2D _rigid2d;

    [Range(.5f, 2f)]
    private float MovementSpeed = 1.5f;

    public float JumpHeight = 8f;

    private float minVelocityX = 0.5f;

    private float maxVelocityX = 7f;

    private float maxSpeedY = 14f;

    public GroundCheck groundCheck;

    public bool IsGrounded = false;

    private bool FlippedX = false;

    private SpriteRenderer _spriteRenderer;

    private Animator _playerAnimator;
    private AudioSource _playerAudioSource;

    private bool IsInAir;

    public AudioClip JumpSound;
    public AudioClip WalkSound;

    void Start()
    {
        _rigid2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAnimator = GetComponent<Animator>();
        _playerAudioSource = GetComponent<AudioSource>();

    }

    //error here in detecting ground :(


    private void Update()
    {
        IsGrounded = groundCheck.CheckIsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            _playerAudioSource.clip = JumpSound;
            _playerAudioSource.Play();
            IsGrounded = false;
            _rigid2d.velocity = new Vector2(_rigid2d.velocity.x, JumpHeight);
        }

        //here we are multiplying gravity when player is in air
        if (IsGrounded)
        {
            IsInAir = false;
            _rigid2d.gravityScale = 1f;
        }
        else
        {
            IsInAir = true;
            _rigid2d.gravityScale = 1.7f;
        }
    }

    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(h, 0f);

        _playerAnimator.SetFloat("Speed", Mathf.Abs(h));

        if (movement.x < 0f)
        {
            FlippedX = true;
        }
        else if (movement.x > 0f)
        {
            FlippedX = false;
        }

        if (movement.x != 0f)
        {
            //playwalking
        }

        if (IsInAir)
        {
            //movement.x = movement.x * 2f;
        }

        _spriteRenderer.flipX = FlippedX;

        SetMaxVelocity(movement);
    }


    private void SetMaxVelocity(Vector2 movement)
    {
        if (Mathf.Abs(_rigid2d.velocity.y) > maxSpeedY)
        {
            var mrClaper = Mathf.Clamp(_rigid2d.velocity.y, -maxSpeedY, maxSpeedY);
            _rigid2d.velocity = new Vector2(_rigid2d.velocity.x, mrClaper);
        }



        if (Mathf.Abs(_rigid2d.velocity.x) > maxVelocityX)
        {
            var mrClaper = Mathf.Clamp(_rigid2d.velocity.x, -maxVelocityX, maxVelocityX);
            _rigid2d.velocity = new Vector2(mrClaper, _rigid2d.velocity.y);
        }
        else
        {
            _rigid2d.AddForce(movement * MovementSpeed * 10f);
        }
    }
}
