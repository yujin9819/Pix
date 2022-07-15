using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialStrawberry : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.instance.SendEvent("Strawberry");
            EventManager.instance.SendEvent("StrawberryText");
            EffectSound.SoundPlay();
            anim.SetTrigger("Collected");
            Destroy(gameObject, .3f);
        }
    }
}
