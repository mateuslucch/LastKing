using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] Sprite openedDoorSprite;
    [SerializeField] Sprite closedDoorSprite;
    [SerializeField] AudioClip openDoorSound;
    [SerializeField] DoorHandler secondDoor;

    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    bool isOpen = false;

    // need key or pressure plate
    [Header("Type of door")]
    [SerializeField] bool isLockable;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoorSprite;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // check if is closed
        if (!isOpen)
        {
            // check if dont need key
            if (!isLockable)
            {
                if (other.gameObject.tag == "Player")
                {
                    OpenDoor(true);
                }
            }
            // else, check if player have key
            else if (other.gameObject.GetComponent<PlayerInventory>().OpenWithKey())
            {
                OpenDoor(true);
            }
        }
    }

    private void OpenDoor(bool thisWasOpen)
    {
        if (FindObjectOfType<Platino>() != null)
        {
            FindObjectOfType<Platino>().AwakePlatino();
        }

        // check if there is a second door, linked in this one
        // remember to link one to another, not only one
        if (secondDoor != null && thisWasOpen)
        {
            secondDoor.OpenDoor(false);
        }
        isOpen = true;
        spriteRenderer.sprite = openedDoorSprite;
        audioSource.PlayOneShot(openDoorSound);
        GetComponent<Collider2D>().enabled = false;
    }

    private void CloseDoor()
    {
        spriteRenderer.sprite = closedDoorSprite;
    }

}
