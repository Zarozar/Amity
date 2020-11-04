using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Edge_Detector : MonoBehaviour
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
        if (other.gameObject.tag == "Edge")
        {
            Debug.Log("turn");
            SkeletonScript.ChangeDirection();
        }
    }
}
