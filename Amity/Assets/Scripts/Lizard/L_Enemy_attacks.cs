using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Enemy_attacks : MonoBehaviour
{
    public GameObject Enemy;

    private Lizard LizardScript;

    // Start is called before the first frame update
    void Start()
    {
        LizardScript = Enemy.GetComponent<Lizard>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().IsDead == false)
        {
            other.GetComponent<Character>().TakeDamage(LizardScript.damage);
        }
    }

}
