using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGSoundScript1.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

