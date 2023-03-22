using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}
    
    new private Rigidbody2D rigidbody2D;
    

    [SerializeField] private float movingSpeed = 200f;
    [SerializeField] private float jumpingForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private SpriteRenderer sprite;
    private AudioSource audioSource;
    private BoxCollider2D coll;
    private Vector2 movingDir;
    private bool isFacingRight = true;

    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool _isBouncing = false;
    
    private float _bounceForceX;
    private float _bounceForceY;

    private void Awake()
    {
        Instance = this;
        coll = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnJump += GameInput_OnJump;
        Trap.OnCollision += Trap_OnCollision;
    }

    private void GameInput_OnJump(object sender, System.EventArgs e)
    {
        if (IsGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpingForce);
            SoundManager.Instance.PlayJumpingSound(transform.position);
        }
    }
    
    private void Trap_OnCollision(object sender, System.EventArgs e)
    {
        Die();
    }
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Trap"))
    //     {
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //     }
    // }
    // Update is called once per frame
    private void FixedUpdate()
    {
        movingDir = GameInput.Instance.GetMovingDirection();
        rigidbody2D.velocity = new Vector2(movingDir.x * movingSpeed * Time.deltaTime, rigidbody2D.velocity.y);

        if (_isBouncing)
        {
            rigidbody2D.velocity = new Vector2(_bounceForceX, _bounceForceY);
            _isBouncing = false;
        }
    }

    void Update()
    {
        Flip();
    }
    
    private void Flip()
    {
        Vector3 localTransform = transform.localScale;
        localTransform.x *= -1f;
        if (!isFacingRight && movingDir.x > 0f)
        {
            isFacingRight = true;
            transform.localScale = localTransform;
        }
        else if (isFacingRight && movingDir.x < 0f)
        {
            isFacingRight = false;
            transform.localScale = localTransform;
        }
    }
    
    private void Die()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        // SoundManager.Instance.PlayDieSound(transform.position);
        audioSource.Play();
    }
    
    public void Bounce(float bounceForceX = 0, float bounceForceY = 0)
    {
        _bounceForceX = bounceForceX == 0 ? rigidbody2D.velocity.x : bounceForceX;
        _bounceForceY = bounceForceY == 0 ? rigidbody2D.velocity.y : bounceForceY;

        _isBouncing = true;

    }
    
    
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, .1f, jumpableGround);
    }
    
    public bool IsMoving()
    {
        isMoving = movingDir.x != 0f;
        return isMoving;
    }
    
    public bool IsJumping()
    {
        isJumping = rigidbody2D.velocity.y > .1f;
        return isJumping;
    }
    
    public bool IsFalling()
    {
        isFalling = rigidbody2D.velocity.y < -.1f && !IsGrounded();
        return isFalling;
    }
    
    
}
