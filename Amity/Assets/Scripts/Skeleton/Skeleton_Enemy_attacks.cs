using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Enemy_attacks : MonoBehaviour
{
    public GameObject Enemy;

    private Skeleton SkeletonScript;

    // Start is called before the first frame update
    void Start()
    {
        SkeletonScript = Enemy.GetComponent<Skeleton>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().IsDead == false)
        {
            other.GetComponent<Character>().TakeDamage(SkeletonScript.damage);
        }
    }

}
