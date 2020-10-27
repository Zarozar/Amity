using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBeast_damaged : MonoBehaviour
{
    public GameObject Enemy;

    private HellBeast HellBeastScript;

    // Start is called before the first frame update
    void Start()
    {
        HellBeastScript = Enemy.GetComponent<HellBeast>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sword")
        {
            HellBeastScript.HellBeastDeath(0.12f);
        }
    }
}
