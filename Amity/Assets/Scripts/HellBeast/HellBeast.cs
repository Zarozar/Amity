using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBeast : MonoBehaviour
{
    public GameObject Target { get; set; }

    [SerializeField]
    private float ShotRange;

    public Animator animator { get; private set; }

    public bool InShotRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= ShotRange;
            }

            return false;
        }
    }
    public bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    private bool facingRight = false;

    [SerializeField]
    public int damage { get; set; }

    [SerializeField]
    protected int health;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    private void Start()
    {
        damage = 10;
        animator = GetComponent<Animator>();
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (!IsDead)
        {
            if (InShotRange && timeBtwShots <= 0)
            {
                animator.SetTrigger("attack");
                timeBtwShots = startTimeBtwShots;
            }
            else 
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        LookAtTarget();
        
        
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
    private void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }
    public void HellBeastDeath(float sec)
    {
        animator.SetTrigger("death");
        StartCoroutine(H_SecondDeath(sec));
    }

    IEnumerator H_SecondDeath(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(this.gameObject);
    }

    private void spawnBalls()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
