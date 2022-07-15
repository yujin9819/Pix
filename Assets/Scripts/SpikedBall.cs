using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    private Vector3 originPos;

    private void Start()
    {
        originPos = transform.position;
        transform.position = new Vector3(originPos.x + 2f, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.instance.SendEvent("PlayerRespawn");
            EventManager.instance.SendEvent("RespawnFallPlat");
        }
    }
}
