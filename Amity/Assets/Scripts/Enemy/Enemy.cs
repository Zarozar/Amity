using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private IEnemyState currentState;
    public GameObject Target { get; set; }

    [SerializeField]
    private float castRange;

    public bool InCastRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= castRange;
            }

            return false;
        }
    }
    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
        damage = 10;
    }


    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if (!TakingDamage)
            {
                currentState.Execute();
            }
            LookAtTarget();
        }
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

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);

    }

    public void Move()
    {
        if (!Attack)
        {
            if (Target != null)
            {
                if (InCastRange == false)
                {
                    animator.SetFloat("speed", 1);

                    transform.Translate(GetDirection() * (speed * Time.deltaTime));
                }
                else
                {
                    animator.SetFloat("speed", 0);
                }
            }
            else 
            {
                animator.SetFloat("speed", 1);

                transform.Translate(GetDirection() * (speed * Time.deltaTime));
            }

        }
 
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;

        if (!IsDead)
        {
            animator.SetTrigger("damaged");
            CloseAttackCollider();
            StartCoroutine(ReturnToIdle());
        }
        else
        {
            animator.SetTrigger("die");
            this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }
    }
    
    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(3.0f);
        ChangeState(new IdleState());
    }
}
