using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cmr;
    public float speed;
    Transform target;
    float initialDistance;
    CircleCollider2D bxc;
    private void Start()
    {
        bxc = GetComponent<CircleCollider2D>();
        initialDistance = 0;
    }
    private void Update()
    {
        if (target != null && initialDistance != 0)
        {
            float d = Vector3.Distance(cmr.position, new Vector3(target.position.x, target.position.y, -1));
            cmr.position = Vector3.MoveTowards(cmr.position, new Vector3(target.position.x, target.position.y, -1), Mathf.Cos((Mathf.PI / 2) * (1 - (d / initialDistance))) * speed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && bxc.IsTouching(collision))
        {
            //cmr.position = new Vector3(collision.transform.position.x, collision.transform.position.y, -1);
            target = collision.transform;
            initialDistance = Vector3.Distance(cmr.position, new Vector3(target.position.x, target.position.y, -1));
        }
    }
}
