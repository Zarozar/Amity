using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard_damaged : MonoBehaviour
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
        if (other.gameObject.tag == "Sword")
        {
            LizardScript.TakeDamage(other.GetComponent<Player>().damage);
        }
    }
}
