using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Damaged : MonoBehaviour
{
    public GameObject Enemy;

    private Frog FrogScript;

    // Start is called before the first frame update
    void Start()
    {
        FrogScript = Enemy.GetComponent<Frog>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().IsDead == false)
        {
            other.GetComponent<Character>().TakeDamage(50);
            FrogScript.animator.SetTrigger("death");
            FrogScript.FrogDeath(0.5f);
        }
        if (other.gameObject.tag == "Sword")
        {
            FrogScript.animator.SetTrigger("death");
            FrogScript.FrogDeath(0.5f);
        }
    }
}
