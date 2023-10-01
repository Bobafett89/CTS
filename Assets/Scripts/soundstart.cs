using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundstart : MonoBehaviour
{
    AudioSource s;
    private void Start()
    {
        s = GetComponent<AudioSource>();
        s.volume = PlayerPrefs.GetFloat("S", 0.5f);
        s.Play();
    }
    private void Update()
    {
        if (!s.isPlaying)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
