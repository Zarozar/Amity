using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    protected bool facingRight;

    [SerializeField]
    protected int health;

    [SerializeField]
    public int damage { get; set; }

    [SerializeField]
    private BoxCollider2D MeleeCollider;

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }
    public Animator animator { get; private set; }

    public Rigidbody2D Rb { get; set; }

    public GameObject Target { get; set; }
    public bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }


    // Start is called before the first frame update
    public void Start()
    {
        damage = 100;
        facingRight = false;
        animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            LookAtTarget();
        }
        else
        {
            Death();
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

    public void Death()
    {
        StartCoroutine(Disappear());
        animator.SetTrigger("attack");
        MeleeAttack();
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3.0f);
        CloseAttackCollider();
        Destroy(this.gameObject);
    }


}
