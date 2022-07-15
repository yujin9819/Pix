using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rigid;

    private void Awake()
    {

    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FallPlatform()
    {
        rigid.isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            FallPlatform();
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }

}
