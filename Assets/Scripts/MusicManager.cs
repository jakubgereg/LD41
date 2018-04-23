using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    public static MusicManager Instance
    {
        get { return instance; }
        set { }
    }

    public AudioSource audioSource
    {
        get; private set;
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

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }
}