using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{

    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(audioClip);
            FindObjectOfType<PortalHandler>().RemoveShardCount();
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
