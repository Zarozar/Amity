﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attacks : MonoBehaviour
{
    public GameObject Enemy;

    private Enemy EnemyScript;

    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        EnemyScript = Enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().IsDead == false)
        {
            FindObjectOfType<AudioManager>().Play("boss_attack");
            other.GetComponent<Character>().TakeDamage(EnemyScript.damage);
        }
    }

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().IsDead == false)
        {
            counter++;
            if (counter % 20 == 0)
            {
                other.GetComponent<Character>().TakeDamage(EnemyScript.damage);
            }
        }
    }
}
