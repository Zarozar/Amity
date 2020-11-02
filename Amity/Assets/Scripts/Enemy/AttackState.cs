using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy enemy;

    private float castTimer;
    private float castCoolDown = 4;
    private bool canCast = true;
    private float attackTimer = 0;
    private float attackDuration = 2;
    public bool isAttacking = false;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        
        if (isAttacking == false)
        {
            CastFire();
        }
        else
        {
            Attacking();
        }
        

        if (enemy.Target != null)
        {
            enemy.Move();
        }
        else 
        {
            enemy.animator.SetTrigger("finish_attack");
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    public virtual void CastFire()
    {
        castTimer += Time.deltaTime;

        if (castTimer >= castCoolDown)
        {
            canCast = true;
            castTimer = 0;
        }

        if (canCast && enemy.InCastRange)
        {
            canCast = false;
            enemy.animator.SetTrigger("attack");

            isAttacking = true;
        }
    }

    private void Attacking()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDuration)
        {
            isAttacking = false;
            enemy.animator.SetTrigger("finish_attack");
            enemy.animator.SetTrigger("attack");
            attackTimer = 0;
        }
    }
}
