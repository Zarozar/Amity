using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attacks : MonoBehaviour
{
    public GameObject Enemy;

    private Enemy EnemyScript;
    // Start is called before the first frame update
    void Start()
    {
        EnemyScript = Enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Character>().TakeDamage(EnemyScript.damage);

        }
    }
}
