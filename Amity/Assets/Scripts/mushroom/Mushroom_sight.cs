using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_sight : MonoBehaviour
{
    [SerializeField]
    private Mushroom enemy;

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