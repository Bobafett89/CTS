using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menubuttons : MonoBehaviour
{
    Vector3 target;
    public float speed;
    private void Start()
    {
        target = new Vector3(0.5f, 0.5f, -1);
    }
    private void Update()
    {
        float d = Vector3.Distance(transform.position, new Vector3(target.x, target.y, -1));
        float localSpeed = Mathf.Cos((Mathf.PI / 2) * (1 - (d / 15))) * speed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, target.y, -1), localSpeed);
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Settings()
    {
        target = new Vector3(-14.5f, 0.5f, -1);
    }
    public void Tutorial()
    {
        target = new Vector3(15.5f, 0.5f, -1);
    }
    public void Next()
    {
        target = new Vector3(30.5f, 0.5f, -1);
    }
    public void Back()
    {
        target = new Vector3(0.5f, 0.5f, -1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
