using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed, rotateSpeed, squashSpeed;
    Rigidbody2D rgd;
    int buttonX, buttonY;
    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        buttonX = buttonY = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        rotate();
        axisButtons();
        if (Modes.Move)
        {
            if (buttonX != 0 && buttonY != 0)
            {
                rgd.velocity = new Vector2((speed * Mathf.Cos(Mathf.PI / 4) * buttonX), (speed * Mathf.Sin(Mathf.PI / 4) * buttonY));
            }
            else if (buttonX != 0)
            {
                rgd.velocity = new Vector2((speed * buttonX), 0);
            }
            else if (buttonY != 0)
            {
                rgd.velocity = new Vector2(0, (speed * buttonY));
            }
            else
            {
                rgd.velocity = Vector2.zero;
            }
        }
        else
        {
            rgd.velocity = Vector2.zero;
        }
    }
    void axisButtons()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            buttonX = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            buttonX = -1;
        }
        else
        {
            buttonX = 0;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            buttonY = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            buttonY = -1;
        }
        else
        {
            buttonY = 0;
        }
    }
    void rotate()
    {
        if (Modes.Move)
        {
            if (transform.localScale != Vector3.one)
            {
                if (buttonX != 0 || buttonY != 0)
                {
                    Quaternion targetR;
                    if (buttonY == 0)
                    {
                        targetR = Quaternion.Euler(0, 0, (Mathf.Acos(buttonX) / Mathf.PI * 180));
                    }
                    else if (buttonX == 0)
                    {
                        targetR = Quaternion.Euler(0, 0, (Mathf.Asin(buttonY) / Mathf.PI * 180));
                    }
                    else
                    {
                        if (buttonY == 1)
                        {
                            targetR = Quaternion.Euler(0, 0, (Mathf.Acos(Mathf.Cos(Mathf.PI / 4) * buttonX) / Mathf.PI * 180));
                        }
                        else
                        {
                            targetR = Quaternion.Euler(0, 0, -(Mathf.Acos(Mathf.Cos(Mathf.PI / 4) * buttonX) / Mathf.PI * 180));
                        }
                    }
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetR, rotateSpeed * Time.deltaTime);
                    transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(1.25f, (20f / 23f), 1), squashSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, squashSpeed * Time.fixedDeltaTime);
                }
            }
            else
            {
                if (buttonX != 0 || buttonY != 0)
                {
                    if (buttonY == 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Acos(buttonX) / Mathf.PI * 180));
                    }
                    else if (buttonX == 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Asin(buttonY) / Mathf.PI * 180));
                    }
                    else
                    {
                        if (buttonY == 1)
                        {
                            transform.rotation = Quaternion.Euler(0, 0, (Mathf.Acos(Mathf.Cos(Mathf.PI / 4) * buttonX) / Mathf.PI * 180));
                        }
                        else
                        {
                            transform.rotation = Quaternion.Euler(0, 0, -(Mathf.Acos(Mathf.Cos(Mathf.PI / 4) * buttonX) / Mathf.PI * 180));
                        }
                    }
                    transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(1.15f, (20f / 23f), 1), squashSpeed * Time.fixedDeltaTime);
                }
            }
        }
        else
        {
            Quaternion targetR = Quaternion.identity;
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, squashSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetR, rotateSpeed * Time.deltaTime);
        }
    }
}
