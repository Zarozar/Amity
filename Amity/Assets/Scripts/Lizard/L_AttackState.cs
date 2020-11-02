using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_AttackState : AttackState
{
    private Lizard enemy;

    private float castTimer;
    private float castCoolDown = 1;
    private bool canCast = true;

    public override void CastFire()
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

}
