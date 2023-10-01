using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    AudioSource mS;
    private void Start()
    {
        mS = GetComponent<AudioSource>();
    }
    private void Update()
    {
        mS.volume = PlayerPrefs.GetFloat("M", 0.5f);
    }
}
