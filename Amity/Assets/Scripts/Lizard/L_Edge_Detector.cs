using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Edge_Detector : MonoBehaviour
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
        if (other.gameObject.tag == "Edge")
        {
            Debug.Log("turn");
            LizardScript.ChangeDirection();
        }
    }
}
