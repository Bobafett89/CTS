using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    CircleCollider2D bxc;
    public GameObject ChargeStaton, RecycleStation, ExpandStation;
    GameObject room;
    private void Start()
    {
        bxc = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (room != null)
        {
            if (Modes.Build && Modes.recycleMeter == 10 && bxc.IsTouchingLayers(LayerMask.GetMask("Room")))
            {
                if (!bxc.IsTouchingLayers(LayerMask.GetMask("ExpandStation")) && !bxc.IsTouchingLayers(LayerMask.GetMask("ChargeStation")) && !bxc.IsTouchingLayers(LayerMask.GetMask("RecycleStation")))
                {
                    Vector3 target = new Vector3((Mathf.Round(transform.position.x / 15) * 15 + 0.5f), (Mathf.Round(transform.position.y / 9) * 9 + 0.5f));
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        GameObject.Instantiate(ExpandStation, target, new Quaternion());
                        room.GetComponentInParent<NewRooms>().moreSpace = true;
                        Modes.recycleMeter = 0;
                        Sound.Build = true;
                    }
                    else if (!bxc.IsTouchingLayers(LayerMask.GetMask("CantBuild")))
                    {
                        if (Input.GetKeyDown(KeyCode.Alpha2))
                        {
                            GameObject.Instantiate(ChargeStaton, target, new Quaternion());
                            Modes.recycleMeter = 0;
                            ScoreSystem.score += 400;
                            Sound.Build = true;
                        }
                        else if (Input.GetKeyDown(KeyCode.Alpha3))
                        {
                            GameObject.Instantiate(RecycleStation, target, new Quaternion());
                            Modes.recycleMeter = 0;
                            ScoreSystem.score += 400;
                            Sound.Build = true;
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bxc.IsTouching(collision) && collision.gameObject.layer == 10)
        {
            room = collision.gameObject;
        }
    }
}
