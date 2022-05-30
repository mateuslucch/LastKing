using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    [SerializeField] AudioClip openBarrierSound;

    AudioSource audioSource;
    bool barrierIsOpen = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !barrierIsOpen)
        {
            barrierIsOpen = true;
            audioSource.PlayOneShot(openBarrierSound);
            barrier.SetActive(false);
        }
    }
}
