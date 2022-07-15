using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollect : MonoBehaviour
{
    Animator anim;
    public int bananaCnt;

    private void Start()
    {
        bananaCnt = 0;
        anim = GetComponent<Animator>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.instance.SendEvent("CollectedFruit");
            EventManager.instance.SendEvent("BananaScore");
            EffectSound.SoundPlay();
            anim.SetTrigger("Collected");
            Destroy(gameObject, .3f);
        }
    }
}
