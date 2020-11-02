using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Character
{
    private bool attacking = false;

    public GameObject Target { get; set; }

    [SerializeField]
    private float tongueRange;

    private float attackCd = 1f;
    private float attackTimer = 0;

    public bool InCastRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= tongueRange;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if (!TakingDamage)
            {
                Move();
            }
            LookAtTarget();
        }
    }

    public void Move()
    {
        if (!attacking)
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
                    animator.SetTrigger("attack");
                    MeleeAttack();
                    Tounge_Attack();
                }
            }
            else
            {
                animator.SetFloat("speed", 1);

                transform.Translate(GetDirection() * (speed * Time.deltaTime));
            }
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
        }
        else
        {
            animator.SetTrigger("death");
            StartCoroutine(Lizard_death(0.3f));
        }
    }

    IEnumerator Lizard_death(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(this.gameObject);
    }

    private void Tounge_Attack()
    {
        attacking = true;
        attackTimer = attackCd;
        CloseAttackCollider();
    }

}
