using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulDamaged : MonoBehaviour
{
    public GameObject Enemy;

    private GhoulWalker GhoulScript;

    // Start is called before the first frame update
    void Start()
    {
        GhoulScript = Enemy.GetComponent<GhoulWalker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().IsDead == false)
        {
            other.GetComponent<Character>().TakeDamage(GhoulScript.damage);
        }
    }

}
