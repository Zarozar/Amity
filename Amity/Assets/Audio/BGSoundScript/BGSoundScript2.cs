using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    //Play Global
    private static BGSoundScript2 instance = null;
    public static BGSoundScript2 Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    //Play Gobal End

    // Update is called once per frame
    void Update()
    {

    }
}