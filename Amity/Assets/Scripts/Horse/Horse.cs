using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public GameObject Target { get; set; }

    [SerializeField]
    private float chargeRange;

    public bool InChargeRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= chargeRange;
            }

            return false;
        }
    }
    public bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    public Animator animator { get; private set; }

    private bool facingRight = false;

    [SerializeField]
    private float speed;

    [SerializeField]
    public int damage { get; set; }

    [SerializeField]
    protected int health;


    private void Start()
    {
        damage = 10;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!IsDead)
        {
            Move();
        }
        LookAtTarget();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    public void HorseDeath(float sec)
    {
        StartCoroutine(SecondDeath(sec));
        speed = 0;
    }

    IEnumerator SecondDeath(float sec)    
    {
        yield return new WaitForSeconds(sec);
        Destroy(this.gameObject);
    }
    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }
    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }
    private void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }
    private void Move()
    {
        if (Target != null)
        {
            if (InChargeRange == true)
            {
                transform.Translate(GetDirection() * (speed * Time.deltaTime));
                animator.SetFloat("speed", 8f);
            }
        }
    }

}
