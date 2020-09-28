using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;


    public Rigidbody2D Rb { get; set; }

    public bool Jump { get; set; }
    public bool OnGround { get; set; }
    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }


    public override void Start()
    {
        base.Start();
        Rb = GetComponent<Rigidbody2D>();
        damage = 10;
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        OnGround = IsGrounded();

        if (!IsDead)
        {
            HandleMovement(horizontal);
            Flip(horizontal);
        }

        HandleLayers();
    }

    private void HandleMovement(float horizontal)
    {
        if (Rb.velocity.y < 0)
        {
            animator.SetBool("land", true);
        }
        if (!Attack && (OnGround || airControl))
        {
            Rb.velocity = new Vector2(horizontal * speed, Rb.velocity.y);
        }

        animator.SetFloat("speed", Mathf.Abs(horizontal));
    }



    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (!IsDead) && OnGround)
        {
            animator.SetTrigger("jump");
            Rb.AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && (!IsDead))
        {
            animator.SetTrigger("attack");
        }
    }


    private bool IsGrounded()
    {
        if (Rb.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!OnGround)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            ChangeDirection();
        }
    }



    public override void TakeDamage(int damage)
    {
        health -= damage;

        if (!IsDead)
        {
            animator.SetTrigger("damaged");
        }
        else
        {
            animator.SetTrigger("die");
        }
    }
}
