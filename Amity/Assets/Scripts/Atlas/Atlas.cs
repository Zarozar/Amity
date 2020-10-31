using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atlas : MonoBehaviour
{
    public Animator animator { get; private set; }

    public int damage { get; set; }

    [SerializeField]
    private float speed;

    private bool facingRight; 

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(GetDirection() * (speed * Time.deltaTime));
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }
}
