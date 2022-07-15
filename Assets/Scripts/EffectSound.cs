using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip fruit;
    public static AudioClip button;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fruit = Resources.Load<AudioClip>("EffectSound/Fruit");
        button = Resources.Load<AudioClip>("EffectSound/ButtonClick");
    }

    public static void SoundPlay()
    {
        audioSource.PlayOneShot(fruit);
    }

    public static void BtnSoundPlay()
    {
        audioSource.PlayOneShot(button);
    }


}
