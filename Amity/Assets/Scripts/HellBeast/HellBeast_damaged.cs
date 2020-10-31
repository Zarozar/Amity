using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBeast_damaged : MonoBehaviour
{
    public GameObject Enemy;

    private HellBeast HellBeast_Script;

    // Start is called before the first frame update
    void Start()
    {
        HellBeast_Script = Enemy.GetComponent<HellBeast>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().IsDead == false)
        {
            HellBeast_Script.HellBeastDeath(1.5f);
            other.GetComponent<Character>().TakeDamage(50);
        }
        if (other.gameObject.tag == "Sword")
        {
            HellBeast_Script.HellBeastDeath(1.5f);
        }
    }
}
