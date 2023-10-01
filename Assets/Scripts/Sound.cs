using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public static bool Pick, Click, Die, Build;
    public GameObject picking, clicking, dying, building;
    public Slider M, S;
    private void Start()
    {
        Pick = Click = Build = false;
    }
    private void Update()
    {
        if (Pick)
        {
            GameObject.Instantiate(picking, Vector3.zero, Quaternion.identity);
            Pick = false;
        }
        if (Click)
        {
            GameObject.Instantiate(clicking, Vector3.zero, Quaternion.identity);
            Click = false;
        }
        if (Build)
        {
            GameObject.Instantiate(building, Vector3.zero, Quaternion.identity);
            Build = false;
        }
        if (Die && dying != null)
        {
            GameObject.Instantiate(dying, Vector3.zero, Quaternion.identity);
            Die = false;
        }
        if (M != null)
        {
            PlayerPrefs.SetFloat("S", S.value);
            PlayerPrefs.SetFloat("M", M.value);
        }
    }
}
