using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSight : MonoBehaviour
{
    [SerializeField]
    private Minion minion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            minion.Target = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            minion.Target = null;
        }
    }
}
