using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firecheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.instance.SendEvent("PlayerRespawn");
            EventManager.instance.SendEvent("fireAnimOff");
            gameObject.SetActive(false);
        }
        
    }

}
