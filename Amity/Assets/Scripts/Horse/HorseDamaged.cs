using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseDamaged : MonoBehaviour
{
    public GameObject Enemy;

    private Horse HorseScript;

    // Start is called before the first frame update
    void Start()
    {
        HorseScript = Enemy.GetComponent<Horse>();
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
            HorseScript.HorseDeath(0.5f);
        }
        if (other.gameObject.tag == "Sword")
        {
            HorseScript.HorseDeath(0.2f);
        }
    }
}
