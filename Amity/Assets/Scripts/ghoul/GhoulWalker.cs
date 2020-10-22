using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulWalker : MonoBehaviour
{
    public GameObject Target { get; set; }

    public int damage;

    [SerializeField]
    private float speed;
    
    private bool facingRight;
    
    [SerializeField]
    private int health;
    
    private Animator animator;
    public bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    public GameObject Explode;

    public void Start()
    {
        //damage = 10;
    }

    private void Update()
    {

        if (!IsDead)
        {
            LookAtTarget();
            Move();
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Sword")
        {
            Destroy(other.gameObject);
            StartCoroutine(SecondDeath(0.5f));
        }
    }

    IEnumerator SecondDeath(float sec)    
    {
        yield return new WaitForSeconds(sec);
        Instantiate(Explode, transform.position, transform.rotation);
        Destroy(this.gameObject);
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
    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }

    public void Move()
    {
        if (Target != null)
        {
            animator.SetFloat("speed", 1);

            transform.Translate(GetDirection() * (speed * Time.deltaTime));
        }
    }
         


    
}
