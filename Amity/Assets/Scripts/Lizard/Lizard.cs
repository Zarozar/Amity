using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Enemy
{ 
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
        ChangeState(new L_IdleState());
        damage = 8;
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
        }
    }

    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(3.0f);
        ChangeState(new IdleState());
    }
}
