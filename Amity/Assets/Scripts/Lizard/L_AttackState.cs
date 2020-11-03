using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_AttackState : IEnemyState
{
    protected Enemy enemy;

    private float castTimer = 4;
    private float castCoolDown = 4;
    private bool canCast = true;
    private float attackTimer = 0;
    public bool isAttacking = false;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {

        Attacking();

        if (enemy.Target != null)
        {
            enemy.Move();
        }
        else
        {
            enemy.animator.SetTrigger("finish_attack");
            enemy.ChangeState(new L_IdleState());
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
        castTimer += Time.deltaTime;
        Debug.Log("attacking");
        if (castTimer >= castCoolDown)
        {
            isAttacking = true;
            enemy.animator.SetTrigger("attack");
            enemy.MeleeAttack();
            castTimer = 0;
        }

        if (isAttacking == true)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= 0.3f)
            {
                enemy.animator.SetTrigger("finish_attack");
                enemy.CloseAttackCollider();
                attackTimer = 0;
                isAttacking = false;
            }
        }
    }

}
