using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text healthText;
    public Slider sliderHp;

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
        damage = 20;
        sliderHp.maxValue = health;
        sliderHp.value = health;
    }

    void Update()
    {
        HandleInput();

        healthText.text = "Health: " + health;

        sliderHp.value = health;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "healthpot" && health <= 75)
        {
            health += 25;
            Destroy(other.gameObject);
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
