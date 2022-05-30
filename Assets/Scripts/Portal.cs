using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Sprite closedPortal;
    [SerializeField] Sprite openedPortal;
    [SerializeField] GameObject portalLight;
    [SerializeField] bool isFinalPortal = false;

    SceneLoader sceneLoader;
    Collider2D portalCollider;
    Animator animator;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = closedPortal;
        sceneLoader = FindObjectOfType<SceneLoader>();
        portalCollider = GetComponent<Collider2D>();
        if (!isFinalPortal)
        {
            portalCollider.enabled = false;
        }

        animator = GetComponent<Animator>();

        if (portalLight.activeSelf == true)
        {
            portalLight.SetActive(false);
        }
    }

    public void OpenPortal()
    {
        portalLight.SetActive(true);
        portalCollider.enabled = true;
        GetComponent<Animator>().SetTrigger("Open");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isFinalPortal)
            {
                sceneLoader.LoadNextScene();
                return;
            }
            animator.SetTrigger("Open");
        }
    }
}

