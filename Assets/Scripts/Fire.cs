using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Animator anim;
    public GameObject fireCheck;
    private void Start()
    {
        anim = GetComponent<Animator>();
        EventManager.instance.AddEvent("fireAnimOff", p => anim.SetTrigger("Idle"));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Hit");
            Invoke("On", 1f);
        }
    }

    private void On()
    {
        anim.SetTrigger("On");
        fireCheck.SetActive(true);
    }
}
