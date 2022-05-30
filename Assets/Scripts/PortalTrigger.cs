using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;
    Animator triggerAnimation;

    //Trigger Removed
    
    private void Awake()
    {
        triggerAnimation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        triggerAnimation.SetTrigger("On");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerAnimation.SetTrigger("Trigger Removed");
            audioSource.PlayOneShot(audioClip);
            FindObjectOfType<PortalHandler>().OpenPortal();
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponentInChildren<Light>());
            StartCoroutine(DestroyObject());
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(audioClip.length);
        Destroy(gameObject);
    }
}
