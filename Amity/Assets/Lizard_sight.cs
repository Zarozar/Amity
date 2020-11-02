using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard_sight : MonoBehaviour
{
    [SerializeField]
    private Lizard enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = null;
        }
    }
}