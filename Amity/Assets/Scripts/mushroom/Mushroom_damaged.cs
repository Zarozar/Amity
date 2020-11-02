using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_damaged : MonoBehaviour
{
    public GameObject Enemy;

    private Mushroom MushroomScript;

    // Start is called before the first frame update
    void Start()
    {
        MushroomScript = Enemy.GetComponent<Mushroom>();
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
            MushroomScript.animator.SetTrigger("death");
            MushroomScript.FrogDeath(0.5f);
        }
        if (other.gameObject.tag == "Sword")
        {
            MushroomScript.animator.SetTrigger("death");
            MushroomScript.FrogDeath(0.5f);
        }
    }
}
