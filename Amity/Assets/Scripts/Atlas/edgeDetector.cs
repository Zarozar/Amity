using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edgeDetector : MonoBehaviour
{
    public GameObject Enemy;

    private Atlas AtlasScript;

    // Start is called before the first frame update
    void Start()
    {
        AtlasScript = Enemy.GetComponent<Atlas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Character>().TakeDamage(50);
        }
        if (other.gameObject.tag == "Edge")
        {
            AtlasScript.ChangeDirection();
        }
    }
}
