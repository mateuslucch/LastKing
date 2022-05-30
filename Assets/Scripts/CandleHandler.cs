using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> candlesLight;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Turn On");
            foreach (GameObject candleLight in candlesLight)
            {
                candleLight.SetActive(true);
            }
        }
    }
}
