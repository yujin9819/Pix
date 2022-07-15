using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform desPos;
    public Transform startPos;
    public Transform endPos;
    [SerializeField]
    [Range(2f, 5f)]
    private float moveSpeed = 2f;

    void Start()
    {
        if (startPos != null)
        {
            transform.position = startPos.position;
            desPos = endPos;
        }
    }

    private void FixedUpdate()
    {
        if (startPos != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
            {
                if (desPos == endPos)
                {
                    desPos = startPos;
                }
                else
                {
                    desPos = endPos;
                }
            }

        }
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
