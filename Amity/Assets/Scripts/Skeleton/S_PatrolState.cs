﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PatrolState : IEnemyState
{
    private Enemy enemy;
    private float patrolTimer;
    private float patrolDuration = 2f;

    public void Enter(Enemy enemy)
    {
        Debug.Log("patrol");
        this.enemy = enemy;
    }

    public void Execute()
    {
        Patrol();

        enemy.Move();

        if (enemy.Target != null && enemy.InCastRange)
        {
            enemy.ChangeState(new S_AttackState());
        }
    }

    public void Exit()
    {
        
    }

      
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log(other.gameObject.name);
        if (other.tag == "Edge")
        {
            enemy.ChangeDirection();
            Debug.Log("turn");
        }
        
    }

    private void Patrol()
    {
        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new S_IdleState());
        }
    }
}
