using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour
{
    public GameObject player;

    private Player PlayerScript;

    void Start()
    {
        PlayerScript = player.GetComponent<Player>();
    }

    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript.TakeDamage(100);
        
    }

}
