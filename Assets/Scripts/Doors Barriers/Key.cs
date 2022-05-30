using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInventory>() != null)
        {
            audioSource.PlayOneShot(audioClip);
            other.GetComponent<PlayerInventory>().GotKey();
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<SpriteRenderer>());            
            StartCoroutine(DestroyObject());
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(audioClip.length);
        Destroy(gameObject);
    }
}
