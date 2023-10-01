using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defaultslide : MonoBehaviour
{
    public bool mus;
    private void Start()
    {
        Slider sl = GetComponent<Slider>();
        if (mus)
        {
            sl.value = PlayerPrefs.GetFloat("M", 0.5f);
        }
        else
        {
            sl.value = PlayerPrefs.GetFloat("S", 0.5f);
        }
    }
}
