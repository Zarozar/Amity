using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_0_audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Level_0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
