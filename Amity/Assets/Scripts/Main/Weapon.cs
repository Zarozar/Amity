using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Player;

    private Player PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = Player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            other.GetComponent<Character>().TakeDamage(PlayerScript.damage);

        }
    }

}
