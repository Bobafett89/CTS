using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    CircleCollider2D bxc;
    public float speed;
    private void Start()
    {
        bxc = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (Modes.Gather && bxc.IsTouchingLayers(LayerMask.GetMask("Magnet")) && (Modes.junkMeter + Modes.recycleMeter) < 9.25f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Modes.pos.position, speed * Time.deltaTime);
            if (bxc.IsTouchingLayers(LayerMask.GetMask("MC")))
            {
                Modes.junkMeter++;
                ScoreSystem.score += 5;
                Sound.Pick = true;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
