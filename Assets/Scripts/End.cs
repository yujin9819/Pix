using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private ParticleSystem confetti;
    Animator anim;
    [SerializeField] BoxCollider2D boxCollider;
    void Start()
    {
        confetti = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confetti.Play();
            anim.SetTrigger("Hit");
            Destroy(boxCollider);
            EventManager.instance.SendEvent("PlayGoalBGM", "goal");
            EventManager.instance.SendEvent("SetGoal");
        }
    }
}
