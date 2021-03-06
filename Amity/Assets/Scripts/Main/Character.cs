﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    [SerializeField]
    public bool facingRight = true;

    [SerializeField]
    public int health;

    [SerializeField]
    public int damage { get; set; }

    [SerializeField]
    private BoxCollider2D MeleeCollider;

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }
    public Animator animator { get; private set; }


    // Start is called before the first frame update
    public virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void TakeDamage(int damage);

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }

    public void MeleeAttack()
    {
        MeleeCollider.enabled = true;
    }

    public void CloseAttackCollider()
    {
        MeleeCollider.enabled = false;
    }
}
