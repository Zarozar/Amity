﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGSoundScript2.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
