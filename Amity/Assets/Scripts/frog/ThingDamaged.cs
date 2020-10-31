using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingDamaged : MonoBehaviour
{
    public GameObject Enemy;

    private Thing ThingScript;

    // Start is called before the first frame update
    void Start()
    {
        ThingScript = Enemy.GetComponent<Thing>();
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
            ThingScript.animator.SetTrigger("death");
            ThingScript.ThingDeath(0.5f);
        }
        if (other.gameObject.tag == "Sword")
        {
            ThingScript.animator.SetTrigger("death");
            ThingScript.ThingDeath(0.5f);
        }
        if (other.gameObject.tag == "Edge")
        {
            ThingScript.ChangeDirection();
        }
    }
}
