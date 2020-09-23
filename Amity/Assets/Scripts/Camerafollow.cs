using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    public Transform playerSamurai;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(playerSamurai.position.x, xMin, xMax), Mathf.Clamp(playerSamurai.position.y, yMin, yMax), transform.position.z);
    }
}
