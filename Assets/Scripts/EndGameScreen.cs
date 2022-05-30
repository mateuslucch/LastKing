using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("Play");
    }

    public void LoadMenu()
    {
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }

}
