using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private bool attacking = false;

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

    private float attackCd = 0.5f;
    private float attackTimer = 0;

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
        health = HealthTracker.PlayerHealth;
        Rb = GetComponent<Rigidbody2D>();
        damage = 20;
        sliderHp.maxValue = 100;
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

        if (!IsDead && !PausedMenu.isGamePaused)
        {
            HandleMovement(horizontal);
            Flip(horizontal);
        }

        HandleLayers();

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && (!IsDead) && !attacking)
        {
            animator.SetTrigger("attack");
            FindObjectOfType<AudioManager>().Play("slice");
            attacking = true;
            attackTimer = attackCd;
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
        if (other.gameObject.tag == "healthpot" && health < 100)
        {
            health = 100;
            Destroy(other.gameObject);
        }
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;

        if (!IsDead)
        {
            animator.SetTrigger("damaged");
            FindObjectOfType<AudioManager>().Play("take_damage");
        }
        else
        {
            animator.SetTrigger("die");
            StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2f);
        HealthTracker.PlayerHealth = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
