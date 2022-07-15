using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            EventManager.instance.SendEvent("PlayerRespawn");
            EventManager.instance.SendEvent("RespawnFallPlat");
        }
    }
}
