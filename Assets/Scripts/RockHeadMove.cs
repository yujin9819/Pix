using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadMove : MonoBehaviour
{
    public Transform desPos;
    public Vector3 originPos;

    Animator anim;
    Rigidbody2D rb;

    private void Awake()
    {
        originPos = transform.position;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    IEnumerator Origin()
    {
        float dis = (transform.position - originPos).sqrMagnitude;
        while (dis> float.Epsilon + .1f)   
        {
            dis = (transform.position - originPos).sqrMagnitude;
            rb.MovePosition(Vector3.Lerp(transform.position, desPos.position, .05f));
            yield return null;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            anim.SetTrigger("hit");
            StartCoroutine(Origin());
        }

        if (collision.collider.CompareTag("Player"))
        {
            EventManager.instance.SendEvent("PlayerRespawn");
            EventManager.instance.SendEvent("RespawnFallPlat");
        }
    }
}
