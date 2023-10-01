using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modes : MonoBehaviour
{
    public static Transform pos;
    public static bool Move, Gather, Recharge, Recycle, Build;
    public static float junkMeter, recycleMeter, charge;
    public float rechargeRate, consumeRate, recylceRate, iconSpeed;
    public Slider chargeBar, junkBar, recycleBar;
    public GameObject MovementIcon, GatherIcon, RecycleIcon, RechargeIcon, BuildIcon, ESIcon, CSIcon, RSIcon;
    Transform localMI, localGI, localRI, localREI, localBI, localESI, localCSI, localRSI;
    CircleCollider2D bxc;
    private void Start()
    {
        Gather = Recharge = Recycle = Build = false;
        Move = true;
        charge = 100;
        junkMeter = 0;
        recycleMeter = 0;
        bxc = GetComponent<CircleCollider2D>();
        pos = GetComponent<Transform>();
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space)) && (Move || Gather || Recycle || Recharge || Build))
        {
            if (Build)
            {
                GameObject.Destroy(localESI.gameObject);
                GameObject.Destroy(localCSI.gameObject);
                GameObject.Destroy(localRSI.gameObject);
            }
            if (Recycle)
            {
                junkMeter = Mathf.Ceil(junkMeter);
                recycleMeter = Mathf.Floor(recycleMeter);
            }
            Move = Gather = Recharge = Recycle = Build = false;
            localMI = GameObject.Instantiate(MovementIcon, transform, false).transform;
            localGI = GameObject.Instantiate(GatherIcon, transform, false).transform;
            localRI = GameObject.Instantiate(RecycleIcon, transform, false).transform;
            localREI = GameObject.Instantiate(RechargeIcon, transform, false).transform;
            localBI = GameObject.Instantiate(BuildIcon, transform, false).transform;
            Sound.Click = true;
        }
        if (!(Move || Gather || Recycle || Recharge || Build))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Move = true;
                Sound.Click = true;
                dall();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Gather = true;
                Sound.Click = true;
                dall();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Recycle = true;
                Sound.Click = true;
                dall();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Recharge = true;
                Sound.Click = true;
                dall();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Build = true;
                Sound.Click = true;
                dall();
                localESI = GameObject.Instantiate(ESIcon, transform, false).transform;
                localCSI = GameObject.Instantiate(CSIcon, transform, false).transform;
                localRSI = GameObject.Instantiate(RSIcon, transform, false).transform;
            }
            else
            {
                float localSpeed = Mathf.Cos((Mathf.PI / 2) * (1 - (Vector2.Distance(localMI.localPosition, new Vector2(0, 2)) / 2))) * iconSpeed * Time.fixedDeltaTime;
                Vector2 d = new Vector2(0, 2);
                localMI.localPosition = Vector2.MoveTowards(localMI.localPosition, d, localSpeed);
                d = new Vector2(2 * Mathf.Cos(Mathf.PI * (-0.4f + 0.5f)), 2 * Mathf.Sin(Mathf.PI * (-0.4f + 0.5f)));
                localGI.localPosition = Vector2.MoveTowards(localGI.localPosition, d, localSpeed);
                d = new Vector2(2 * Mathf.Cos(Mathf.PI * (-0.4f * 2 + 0.5f)), 2 * Mathf.Sin(Mathf.PI * (-0.4f * 2 + 0.5f)));
                localRI.localPosition = Vector2.MoveTowards(localRI.localPosition, d, localSpeed);
                d = new Vector2(2 * Mathf.Cos(Mathf.PI * (-0.4f * 3 + 0.5f)), 2 * Mathf.Sin(Mathf.PI * (-0.4f * 3 + 0.5f)));
                localREI.localPosition = Vector2.MoveTowards(localREI.localPosition, d, localSpeed);
                d = new Vector2(2 * Mathf.Cos(Mathf.PI * (-0.4f * 4 + 0.5f)), 2 * Mathf.Sin(Mathf.PI * (-0.4f * 4 + 0.5f)));
                localBI.localPosition = Vector2.MoveTowards(localBI.localPosition, d, localSpeed);
            }

        }


        if (Move || Recycle || Gather)
        {
            charge -= consumeRate * Time.deltaTime;
            if (Recycle && bxc.IsTouchingLayers(LayerMask.GetMask("RecycleStation")))
            {
                if (junkMeter > 0)
                {
                    float localRate = recylceRate * Time.deltaTime;
                    junkMeter -= localRate;
                    recycleMeter += localRate;
                }
                else
                {
                    junkMeter = 0;
                    recycleMeter = Mathf.Floor(recycleMeter);
                }
            }
        }
        else if (Recharge && bxc.IsTouchingLayers(LayerMask.GetMask("ChargeStation")))
        {
            if (charge < 100)
            {
                charge += rechargeRate * Time.deltaTime;
            }
            else
            {
                charge = 100;
            }
        }
        else
        {
            charge -= consumeRate * Time.deltaTime * 0.5f;
            if (Build)
            {
                float localSpeed = Mathf.Cos((Mathf.PI / 2) * (1 - (Vector2.Distance(localESI.localPosition, new Vector2(0, 2)) / 2))) * iconSpeed * Time.fixedDeltaTime;
                Vector2 d = new Vector2(0, 2);
                localESI.localPosition = Vector2.MoveTowards(localESI.localPosition, d, localSpeed);
                d = new Vector2(2 * Mathf.Cos(Mathf.PI * (-(2f / 3f) + 0.5f)), 2 * Mathf.Sin(Mathf.PI * (-(2f / 3f) + 0.5f)));
                localCSI.localPosition = Vector2.MoveTowards(localCSI.localPosition, d, localSpeed);
                d = new Vector2(2 * Mathf.Cos(Mathf.PI * (-(2f / 3f) * 2 + 0.5f)), 2 * Mathf.Sin(Mathf.PI * (-(2f / 3f) * 2 + 0.5f)));
                localRSI.localPosition = Vector2.MoveTowards(localRSI.localPosition, d, localSpeed);
            }
        }

        chargeBar.value = charge / 100;
        junkBar.value = junkMeter / 10;
        recycleBar.value = recycleMeter / 10;
    }
    void dall()
    {
        GameObject.Destroy(localMI.gameObject);
        GameObject.Destroy(localGI.gameObject);
        GameObject.Destroy(localRI.gameObject);
        GameObject.Destroy(localREI.gameObject);
        GameObject.Destroy(localBI.gameObject);
    }
}
