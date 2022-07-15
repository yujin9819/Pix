using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public Transform desPos;
    public Transform startPos;
    public Transform endPos;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        if (startPos != null)
        {
            transform.position = startPos.position;
            desPos = endPos;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (startPos != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * 3f);
            if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
            {
                if (desPos == endPos)
                {
                    desPos = startPos;
                    spriteRenderer.flipX = true;
                }
                else
                {
                    desPos = endPos;
                    spriteRenderer.flipX = false;
                }
            }

        }
    }
}
