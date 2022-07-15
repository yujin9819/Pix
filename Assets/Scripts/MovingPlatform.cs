using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform desPos;
    public Transform startPos;
    public Transform endPos;
    private float moveSpeed;

    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;

        moveSpeed = 2f;
    }

    private void FixedUpdate()
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
